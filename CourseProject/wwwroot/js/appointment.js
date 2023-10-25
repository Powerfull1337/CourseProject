
    flatpickr("#basic", {
        dateFormat: "d-m-Y",
    enableTime: false,
	});

    function validateForm() {
    var firstName = document.forms["contactform"]["FirstName"].value;
    var lastName = document.forms["contactform"]["LastName"].value;
    var email = document.forms["contactform"]["Email"].value;
    var phone = document.forms["contactform"]["Phone"].value;
    var dateOfBook = document.forms["contactform"]["DateOfBook"].value;
    var description = document.forms["contactform"]["Description"].value;

    if (firstName === "" || lastName === "" || email === "" || phone === "" || dateOfBook === "" || description === "") {
        alert("Будь ласка, заповніть всі обов'язкові поля.");
    return false;
    }

    if (!isValidEmail(email)) {
        alert("Будь ласка, введіть коректну email-адресу.");
    return false;
    }

    return true;
}

    function isValidEmail(email) {
        var emailRegex = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$/;
    return emailRegex.test(email);
}
