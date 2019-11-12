window.addEventListener('load',
    function () {//$(function () {
        var chat = $.connection.plantHub;
        var $plantContainer = $('#PlantContainer');

        

        
        

    chat.client.sendMessage = function (name) {
        var json = JSON.parse(name);

        
        $.each(json, function (index, object) {

            if (object.secondsWatered > 0) {
                $('#card_' + object.Id).css('background-color', '#c2f0c2');
            } else {
                $('#card_' + object.Id).css('background-color', '#ffcce0');
            }


            
            $('#time_' + object.Id).text(object.lastTimeWatered);
            $('#progress_' + object.Id).css('width', object.secondsWatered*10+'%');//.attr("aria-valuenow", object.secondsWatered);
            
        });

    };

   

    $(document).on('click', '.btnStart', function (e) {

        console.log({ "Id": $(this).data("value"), "startWatering": true });

        $.post("api/plants/water", { "Id": $(this).data("value"), "startWatering": true }).
            done(function (data) {
            });


    });

    $(document).on('click', '.btnStop', function (e) {


        $.post("api/plants/water", { "Id": $(this).data("value"), "startWatering": false });

    });


    $.connection.hub.start().done(function () {
        console.log("connection started");
        alert("Connected!");
        $.get("api/plants/getAll").
            done(function (data) {
                console.log("Data Loaded: " + data);
            });
        
       
    });
    $.connection.hub.disconnected(function () {
        console.log("connection stopped");
        setTimeout(function () {
            $.connection.hub.start().done(function() {
            });
        }, 5000); // Restart connection after 5 seconds.
    });
});