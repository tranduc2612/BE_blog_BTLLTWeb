let isSubmitPass = false;
let isSubmitAccount = false;
$(".btn-login").on("click", function (e) {
	if (!isSubmitPass || !isSubmitAccount) {
		e.preventDefault();
	}
	
});

$("#accountInput-login").on("focus", function () {
	if(!isSubmitAccount)
	    $(".account_required").slideDown();
});

$("#accountInput-login").on("blur", function (e) {
	if (isSubmitAccount) {
		$(".account_required").slideUp();
	}
});


$("#accountInput-login").on("keyup", function () {
	accountValue = $(this).val();
	let count = 0;

	if (accountValue != "") {
		$(".username").addClass("active");
		
	} else {
		$(".username").removeClass("active");
		count++;
	}
	if (count == 0) {
		isSubmitAccount = true;
	} else {
		isSubmitAccount = false;
	}
	
	
});


function IsEmail(email) {
	var regex =
		/^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
	if (!regex.test(email)) {
		return false;
	} else {
		return true;
	}
}

$("#passwordInput-login").on("focus", function () {
	if (!isSubmitPass) {
		$(".password_required").slideDown();
	}
});

$("#passwordInput-login").on("blur", function (e) {
	if (isSubmitPass) {
		$(".password_required").slideUp();
	}
});

$("#passwordInput-login").on("keyup", function () {
	let count = 0;
	passValue = $(this).val();

	if(passValue != ""){
        $('.empty').addClass('active');
    
    } else{
        $('.empty').removeClass('active');
        count++;
    } 
	if (passValue.match(/[a-z]/g)) {
		$(".Lowercase").addClass("active");
	} else {
		$(".Lowercase").removeClass("active");
		count++;

	}
	if (passValue.match(/[A-Z]/g)) {
		$(".Captital").addClass("active");
	} else {
		$(".Captital").removeClass("active");
		count++;
	}
	if (passValue.match(/[0-9]/g)) {
		$(".Number").addClass("active");
	} else {
		$(".Number").removeClass("active");
		count++;
	}
	if (passValue.match(/[!@#$%^&*]/g)) {
		$(".Special").addClass("active");
	} else {
		$(".Special").removeClass("active");
		count++;
	}
	if (passValue.length == 8 || passValue.length > 8) {
		$(".eight_ch").addClass("active");
	} else {
		$(".eight_ch").removeClass("active");
		count++;
	}

	if (count == 0) {
		isSubmitPass = true;
	} else {
		isSubmitPass = false;
	}
});

