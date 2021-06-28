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
    } else {
        mySteps.style.display = 'block';
        startCooking.innerHTML = 'Stop Cooking';
    }
}


function toggleCategories() {
    var selectedCategories = document.getElementById('breakfast');

    //var displaySetting = selectedCategories.style.display;
    selectedCategories.style.hide = true;
    /*   var startCooking = document.getElementById('breakfast');*/

    //if (displaySetting == 'block') {
    //    selectedCategories.style.display = 'none';
    //    startCooking.innerHTML = 'DO Stuff Breakfast';
    //} else {
    //    selectedCategories.style.display = 'block';
    //    startCooking.innerHTML = 'Stop Cooking';
    //}


}


function toggleStepByStep() {
    var prev = $('.prev');
    var next = $('.next');
    var num = 0;

    $('.li').hide();
    $('.li').eq(0).show();

    next.on('click',
        function() {
            $('.li').hide();
            num++;
            if (num > 3) {
                num = 0;
            }
            $('.li').eq(num).show();
        });

    prev.on('click',
        function() {
            $('.li').hide();
            num--;
            if (num < 0) {
                num = 3;
            }
            $('.li').eq(num).show();
        });
}

var checkList = document.getElementById('list1');
checkList.getElementsByClassName('anchor')[0].onclick = function(evt) {
    if (checkList.classList.contains('visible'))
        checkList.classList.remove('visible');
    else
        checkList.classList.add('visible');
}


filterSelection("all")
function filterSelection(c) {
    var x, i;
    x = document.getElementsByClassName("filterDiv");
    if (c == "all") c = "";
    // Add the "show" class (display:block) to the filtered elements, and remove the "show" class from the elements that are not selected
    for (i = 0; i < x.length; i++) {
        recipeRemoveClass(x[i], "show");
        if (x[i].className.indexOf(c) > -1) recipeAddClass(x[i], "show");
    }
}

// Show filtered elements
function recipeAddClass(element, name) {
    var i, arr1, arr2;
    arr1 = element.className.split(" ");
    arr2 = name.split(" ");
    for (i = 0; i < arr2.length; i++) {
        if (arr1.indexOf(arr2[i]) == -1) {
            element.className += " " + arr2[i];
        }
    }
}

// Hide elements that are not selected
function recipeRemoveClass(element, name) {
    var i, arr1, arr2;
    arr1 = element.className.split(" ");
    arr2 = name.split(" ");
    for (i = 0; i < arr2.length; i++) {
        while (arr1.indexOf(arr2[i]) > -1) {
            arr1.splice(arr1.indexOf(arr2[i]), 1);
        }
    }
    element.className = arr1.join(" ");
}

// Add active class to the current control button (highlight it)
var btnContainer = document.getElementById("myBtnContainer");
var btns = btnContainer.getElementsByClassName("btn-filter");
for (var i = 0; i < btns.length; i++) {
    btns[i].addEventListener("click", function () {
        var current = document.getElementsByClassName("active");
        current[0].className = current[0].className.replace(" active", "");
        this.className += " active";
    });
}




