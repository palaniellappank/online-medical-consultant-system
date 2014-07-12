var OMCSChat = OMCSChat || {};

// todo:
//  cleanup: proper module loading
//  cleanup: promises to clear up some of the async chaining
//  feature: multiple chat partners

OMCSChat.App = (function (connectionManager) {
    var _mediaStream,
        _hub,

        _init = function () {
            // Set Up SignalR Signaler
            var hub = $.connection.chatHub;
            _hub = hub;
            // Setup client SignalR operations
            console.log("Go to _init");

            _setupHubCallbacks(_hub);
            connectionManager.initialize(_hub.server, _callbacks.onReadyForStream, _callbacks.onStreamAdded, _callbacks.onStreamRemoved);

        },

        _setupHubCallbacks = function (hub) {
            if (webrtcDetectedBrowser == null) {
                console.log('Your browser doesnt appear to support WebRTC.');
            };
            console.log("Go to _setupHubCallbacks");

            // Hub Callback: Call Accepted
            hub.client.callAccepted = function (acceptingUser) {
                console.log('call accepted from: ' + JSON.stringify(acceptingUser) + '.  Initiating WebRTC call and offering my stream up...');

                // Callee accepted our call, let's send them an offer with our video stream
                //connectionManager.initiateOffer(acceptingUser.ConnectionId, _mediaStream);
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
                //Doctor no need to add stream
                //connection.addStream(_mediaStream);
            },
            onStreamAdded: function (connection, event) {
                console.log('Binding stream from patient to doctor');

                $("#patientWebcam").css("display", "block");
                var videoElement = document.querySelector('.video.patient');
                attachMediaStream(videoElement, event.stream);
                var bottom = window.innerHeight - Number.parseInt($(".draggable").css("height")) - 90;
                if (bottom < 0) bottom = 0;
                $(".draggable").offset({ top: bottom, left: 30 });                
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
        getStream: function () { // Temp hack for the connection manager to reach back in here for a stream
            return _mediaStream;
        }
    };
})(OMCSChat.ConnectionManager);

OMCSChat.App.init();