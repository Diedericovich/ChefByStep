// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function toggleSteps() {
    var mySteps = document.getElementById('start-cooking');

    var displaySetting = mySteps.style.display;

    var startCooking = document.getElementById('startCooking');

    if (displaySetting == 'block') {
        mySteps.style.display = 'none';
        startCooking.innerHTML = 'Start Cooking';
    }
    else {
        mySteps.style.display = 'block';
        startCooking.innerHTML = 'Stop Cooking';
    }
}

function toggleStepByStep() {
    var prev = $('.prev');
    var next = $('.next');
    var num = 0;

    $('.li').hide();
    $('.li').eq(0).show();

    next.on('click', function () {
        $('.li').hide();
        num++;
        if (num > 3) {
            num = 0;
        }
        $('.li').eq(num).show();
    });

    prev.on('click', function () {
        $('.li').hide();
        num--;
        if (num < 0) {
            num = 3;
        }
        $('.li').eq(num).show();
    });
}