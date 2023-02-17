let isSubmit = false;
$("#emailInput-login").on("change", (e) => {
	const emailValue = e.target.value;

	if (emailValue == "") {
		console.log("hello");
		isSubmit = false;
		$(".alert-box--error").removeClass("d-none");
		
	} else {
		isSubmit = true;
		$(".alert-box--error").addClass("d-none");
	}
});

$(".btn-login").on("click", function (e) {
	if (!isSubmit) {
		e.preventDefault();
	}
});