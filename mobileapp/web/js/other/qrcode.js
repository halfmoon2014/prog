$('#reader').html5_qrcode(function (data) {
    // do something when code is read
    $('#read').html(data);
},
    function (error) {
        //show read errors 
    }, function (videoError) {
        //the video stream could be opened
    }
);