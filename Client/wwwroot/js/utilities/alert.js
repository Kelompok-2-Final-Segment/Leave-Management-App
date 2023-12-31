class Alert {
    static error() {
        Swal.fire({
            icon: 'error',
            title: 'Failed to Create Employee and Account',
            text: 'Something went wrong! Please check your data.',
            footer: '<a href="">Why do I have this issue?</a>'
        });
    }

    static success(message) {
        Swal.fire({
            icon: 'success',
            title: 'Success',
            text: message
        });
    }
}

export default Alert;