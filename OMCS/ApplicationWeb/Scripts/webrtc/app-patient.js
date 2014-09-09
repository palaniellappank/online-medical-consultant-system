var OMCSChat = OMCSChat || {};

// todo:
//  cleanup: proper module loading
//  cleanup: promises to clear up some of the async chaining
//  feature: multiple chat partners

OMCSChat.App = (function (connectionManager) {
    var _mediaStream,
        _hub,
        _doctor,
        _init = function(username) {
            // Set Up SignalR Signaler
            var hub = $.connection.chatHub;
            _hub = hub;
            // Setup client SignalR operations
            console.log("Go to _init");
            
            _setupHubCallbacks(_hub);
        },

        _startSession = function (username) {
            console.log("Go to _startSession");
            if (webrtcDetectedBrowser == null) {
                console.log('Your browser doesnt appear to support WebRTC.');
            };
            // Ask the user for permissions to access the webcam and mic
            getUserMedia(
                {
                    // Permissions to request
                    video: true,
                    audio: false
                },
                function (stream) {                     
                    console.log('initializing connection manager');
                    connectionManager.initialize(_hub.server, _callbacks.onReadyForStream, _callbacks.onStreamAdded, _callbacks.onStreamRemoved);
                        
                    // Store off the stream reference so we can share it later
                    _mediaStream = stream;

                    $(".webcam-content").css("display", "block");
                    var videoElement = document.querySelector('.video.patient');
                    attachMediaStream(videoElement, _mediaStream);

                    console.log("answerCall" + _doctor.ConnectionId);
                    _hub.server.answerCall(true, _doctor.ConnectionId);
                },
                function (error) { // error callback
                    bootbox.alert('<h4>Failed to get hardware access!</h4> Do you have another browser type open and using your cam/mic?<br/><br/>You were not connected to the server, because I didn\'t code to make browsers without media access work well. <br/><br/>Actual Error: ' + JSON.stringify(error));
                }
            );
        },
        
        _setupHubCallbacks = function (hub) {
            console.log("Go to _setupHubCallbacks");

            hub.client.requestWebcamReceived = function (doctorRequest) {
                bootbox.confirm("Bạn nhận được yêu cầu xem webcam từ bác sĩ: " + doctorRequest.FullName + ".<hr> Bạn có muốn chia sẻ webcam?", function (result) {
                    if (result) {
                        // I want to chat
                        _doctor = doctorRequest;
                        _startSession("sutran");
                    } else {
                        // Go away, I don't want to chat with you
                        hub.server.answerCall(false, doctorRequest.ConnectionId);
                    }
                });
            };

            // Hub Callback: Call Accepted
            hub.client.callAccepted = function (acceptingUser) {
                console.log('call accepted from: ' + JSON.stringify(acceptingUser) + '.  Initiating WebRTC call and offering my stream up...');

                // Callee accepted our call, let's send them an offer with our video stream
                connectionManager.initiateOffer(acceptingUser.ConnectionId, _mediaStream);
            };

            // Hub Callback: Call Declined
            hub.client.callDeclined = function (decliningConnectionId, reason) {
                console.log('call declined from: ' + decliningConnectionId);

                // Let the user know that the callee declined to talk
                bootbox.error(reason);

            };

            // Hub Callback: Call Ended
            hub.client.callEnded = function (connectionId, reason) {
                console.log('call with ' + connectionId + ' has ended: ' + reason);

                // Let the user know why the server says the call is over
                bootbox.error(reason);

                // Close the WebRTC connection
                connectionManager.closeConnection(connectionId);
            };

            // Hub Callback: WebRTC Signal Received
            hub.client.receiveSignal = function (callingUser, data) {
                connectionManager.newSignal(callingUser.ConnectionId, data);
            };
        },

        // Connection Manager Callbacks
        _callbacks = {
            onReadyForStream: function (connection) {
                // The connection manager needs our stream
                // todo: not sure I like this
                connection.addStream(_mediaStream);
            },
            onStreamAdded: function (connection, event) {
                console.log('binding remote stream to the partner window');

                // Bind the remote stream to the partner window
                var otherVideo = document.querySelector('.video.partner');
                $(".webcam-content").css("display", "block");
                attachMediaStream(otherVideo, event.stream); // from adapter.js
            },
            onStreamRemoved: function (connection, streamId) {
                // todo: proper stream removal.  right now we are only set up for one-on-one which is why this works.
                console.log('removing remote stream from partner window');
                
                // Clear out the partner window
                var otherVideo = document.querySelector('.video.partner');
                otherVideo.src = '';
            }
        };

    return {
        init: _init, // Starts the UI process
        getStream: function() { // Temp hack for the connection manager to reach back in here for a stream
            return _mediaStream;
        }
    };
})(OMCSChat.ConnectionManager);