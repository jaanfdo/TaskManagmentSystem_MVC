
function displayTodayDate() {
    var now = new Date();
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = now.getFullYear() + "-" + (month) + "-" + (day);

    return today;
}

function displayDate(dates) {
    //console.log(dates);
    var now = new Date(dates);
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = now.getFullYear() + "-" + (month) + "-" + (day);

    return today;
}


function Validate_EmptyFields(Element) {
    var bValue = true;
    //console.log('OK');
    //console.log($(Element));
    //console.log(Element.val());
    if (Element.val() == "") {
        bValue = false;
        //console.log(Element);
        Element.css('border-color', 'red');//.addClass("redborder");
    } else {
        Element.css('border-color', '');
    }


    return bValue;
}


function ForeignKeys(Elements) {
    if (Elements == '') {
        Elements = '-1';
    }

    return Elements;
}

//var textarea = document.querySelector('textarea');
//textarea.addEventListener('keydown', autosize);
//function autosize() {
//    var el = this;
//    setTimeout(function () {
//        el.style.cssText = 'height:auto; padding:0';
//        // for box-sizing other than "content-box" use:
//        // el.style.cssText = '-moz-box-sizing:content-box';
//        el.style.cssText = 'height:' + el.scrollHeight + 'px';
//    }, 0);
//}

//document.addEventListener("click", function () {
//    document.getElementById("demo").innerHTML = "Hello World!";
//});