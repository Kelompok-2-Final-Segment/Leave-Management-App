function redirectHandler(url, timeout) {
    setTimeout(() => {
        // Redirect to path
        window.location.href = url;
    }, timeout);
}