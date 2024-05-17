window.getScrollInfo = (elementId) => {
    const element = document.getElementById(elementId);
    if (!element) return null;
    return {
        scrollTop: element.scrollTop,
        scrollHeight: element.scrollHeight,
        clientHeight: element.clientHeight,
        windowHeight: window.innerHeight
    };
}