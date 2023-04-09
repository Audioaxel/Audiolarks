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


// ===================================================== 
/// Modal

function subscribeCloseModal(elementId, dotnetInstance) {
    myModalEl = document.getElementById(elementId);
  
    // Die benannte Funktion `handleModalHidden` als Event-Listener registrieren
    myModalEl.addEventListener('hidden.bs.modal', handleModalHidden);
  
    function handleModalHidden(event) {
      console.log('Das Modal-Element wurde ausgeblendet.');
      dotnetInstance.invokeMethodAsync('StopVideo');
      myModalEl.removeEventListener('hidden.bs.modal', handleModalHidden);
    }
  }


function autoPlayVideo(elementId) {
    var videoElement = document.getElementById(elementId);
    
    if (videoElement != null)
        videoElement.play();
}
function autoStopVideo(elementId) {
    var videoElement = document.getElementById(elementId);
    
    if (videoElement != null)
        videoElement.pause();
}



