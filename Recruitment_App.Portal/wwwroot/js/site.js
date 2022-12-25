
Notiflix.Confirm.Init({
    rtl: false,
    fontFamily: 'Quicksand',
    titleColor: '#e90000',
    messageColor: '#1e1e1e',
    okButtonColor: '#f8f8f8',
    okButtonBackground: "#e90000",
    cancelButtonColor: '#f8f8f8',
    cancelButtonBackground: '#a9a9a9',
    plainText: true
});
Notiflix.Notify.Init({
    position: 'right-bottom',
    timeout: 3000,
    useFontAwesome: true,
    closeButton: false,
    cssAnimation: true,
    cssAnimationDuration: 400,
    cssAnimationStyle: 'fade',
    opacity: 1,
});
Notiflix.Report.Init({
    success: { svgColor: "#fedf07", buttonBackground: "#fedf07" }
});
Notiflix.Loading.Init({ className: 'notiflix-loading', zindex: 4000, backgroundColor: 'rgba(0,0,0,0.8)', rtl: false, useGoogleFont: true, fontFamily: 'Quicksand', cssAnimation: true, cssAnimationDuration: 400, clickToClose: false, customSvgUrl: null, svgSize: '80px', svgColor: '#c6b732', messageID: 'NotiflixLoadingMessage', messageFontSize: '15px', messageColor: '#dcdcdc' });


