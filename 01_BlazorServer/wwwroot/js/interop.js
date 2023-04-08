function createAlert() {
    alert("alaaaarm");
    var myModalEl = document.getElementById('exampleModal')
    myModalEl.addEventListener('hidden.bs.modal', function (event) {
        console.log('Das Modal-Element wurde ausgeblendet.');
    })
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


// === Scroll Shit ===========================

window.onscroll = function() {
    if (window.scrollInfoService != null)
        window.scrollInfoService.invokeMethodAsync('OnScroll', parseInt(window.pageYOffset));
}

window.RegisterScrollInfoService = (scrollInfoService) => {
    window.scrollInfoService = scrollInfoService;
}

// === Video Callback =========================
function videoPlayCallback(dotnetInstance) {
    dotnetInstance.invokeMethodAsync('OnVideoPlay');
  }

// brauch ich die???
function onModalClose(dotnetInstance) {
    dotnetInstance.invokeMethodAsync('ModalClose');  
}

// Modal
function modalTest() {
    var myModalEl = document.getElementById('exampleModal')
    myModalEl.addEventListener('hidden.bs.modal', function (event) {
        console.log('Das Modal-Element wurde ausgeblendet.');
    })
}


