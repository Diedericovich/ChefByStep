// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function toggleSteps() {
    // get the steps
    var mySteps = document.getElementById('start-cooking');

    // get the current value of the clock's display property
    var displaySetting = mySteps.style.display;

    // also get the clock button, so we can change what it says
    var startCooking = document.getElementById('startCooking');

    // now toggle the clock and the button text, depending on current state
    if (displaySetting == 'block') {
        // clock is visible. hide it
        mySteps.style.display = 'none';
        // change button text
        startCooking.innerHTML = 'Show steps';
    }
    else {
        // clock is hidden. show it
        mySteps.style.display = 'block';
        // change button text
        startCooking.innerHTML = 'Hide steps';
    }
}