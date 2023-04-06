function createAlert() {
    alert("alaaaarm");
}

function createPrompt(text) {
    return prompt(text);
}

function setTextById(id, text) {
    document.getElementById(id).innerText = text;
}

function focusOnElement(element) {
    element.focus();
}

function giveMeRandomInt(maxIntSize) {
    DotNet.invokeMethodAsync('BlazorServer', 'GenerateRandomInt', maxIntSize)
        .then(result => {
            setTextById('spanNum', result);
        });
}

function giveMeRandomInt2(maxIntSize, dotnetInstance) {
    dotnetInstance.invokeMethodAsync('GenerateRandomInt2', maxIntSize)
        .then(result => {
            setTextById('spanNum2', result);
        });
}


// ====================

window.onscroll = function() {
    if (window.scrollInfoService != null)
        window.scrollInfoService.invokeMethodAsync('OnScroll', parseInt(window.pageYOffset));
}

window.RegisterScrollInfoService = (scrollInfoService) => {
    window.scrollInfoService = scrollInfoService;
}