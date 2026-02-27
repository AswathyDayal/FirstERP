document.addEventListener('DOMContentLoaded', () => {
    const successAlert = document.querySelector('.alert-success');
    if (successAlert) {
        setTimeout(() => successAlert.remove(), 3500);
    }
});
