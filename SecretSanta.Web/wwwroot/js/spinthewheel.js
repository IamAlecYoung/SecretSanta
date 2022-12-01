function InjectSpinner(selectedPerson) {
    
    console.log("THis actually works")
    
    var sfx = document.getElementById("roulettewheelsound");

    var option = {
        speed : 15,
        duration : 1,
        stopImageNumber :selectedPerson,
        startCallback : function() {
            sfx.play();
        },
        slowDownCallback : function() {
            //console.log(\'slowDown\');
        },
        stopCallback : function($stopElm) {
            sfx.pause();
            setTimeout(() => {
                $('.stop').hide();
                $('.finished').show();
                //window.location = "Whoyougot"
            }, 1000);
        }
    }
    
    var rouletter = $('div.roulette').roulette(option);

    $('.start').click(function(){
        rouletter.roulette('start');
        $('.start').hide();
        $('spinwheeltext').val = "Spinning...";
        $('.stop').show();
    });    
}

