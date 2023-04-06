window.onscroll = function() {
    if (window.scrollInfoService != null)
        window.scrollInfoService.invokeMethodAsync('OnScroll', window.pageYOffset);
}

window.RegisterScrollInfoService = (scrollInfoService) => {
    window.scrollInfoService = scrollInfoService;
}