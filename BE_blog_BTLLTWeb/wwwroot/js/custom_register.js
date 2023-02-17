let isSubmitAccRe = false;
let isSubmitEmailRe = false;
let isSubmitPassRe = false;
let isSubmitCheckPassRe = false;
$(".btn-login").on("click", function (e) {
	if (!isSubmitAccount || !isSubmitEmail || !isSubmitPass || !isSubmitCheckPass) {
		e.preventDefault();
	}
});
//account
$('#accountInput-register').on('focus', function(){
	if(!isSubmitAccRe)
	      $('.accountInput-register').slideDown();
  })

  $('#accountInput-register').on('blur', function(e){
	  if(isSubmitAccRe){		
		  $('.accountInput-register').slideUp();
		}
  })

$('#accountInput-register').on('keyup', function(){

	let count = 0;
	accountValue = $(this).val();

	
    if(accountValue.match(/[a-zA-Z0-9_\.\-\+]/g)){
		$('.empty_account').addClass('active');
		
	}else{
		$('.empty_account').removeClass('active');
		count++;
	}

	if (count == 0) {
		isSubmitAccRe = true;
	} else {
		isSubmitAccRe = false;
	}

 });
//email
$('#emailInput-register').on('focus', function(){
	if(!isSubmitEmailRe){
		$('.emailInput-register').slideDown();
	}
    
});
$('#emailInput-register').on('blur', function(e){
    if(isSubmitEmailRe){
        $('.emailInput-register').slideUp();
    }
});

$('#emailInput-register').on('keyup', function(){

	let count = 0;
    emailValue = $(this).val();

    if(emailValue != ""){
        $('.empty_email').addClass('active');
    
    } else{
        $('.empty_email').removeClass('active');
        count++;
    } 
    if(emailValue.match(/^([\w-]+(\?\:\.[\w-]+)*)@((\?\:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(\?\:\.[a-z]{2})?)$/g)){
        $('.Email_required').addClass('active');
    
    } else {
        $('.Email_required').removeClass('active');
        count++;
    }

	if (count == 0) {
		isSubmitEmailRe = true;
	} else {
		isSubmitEmailRe = false;
	}

});

//password
  $('#passwordInput-register').on('focus', function(){
	if(!isSubmitPassRe){
		$('.password_required').slideDown();
	}
	
  })

  $('#passwordInput-register').on('blur', function(e){
	  if(isSubmitPassRe){
		  $('.password_required').slideUp();
	  }
		
  })

  $('#passwordInput-register').on('keyup', function(){

	let count = 0;
	passValue = $(this).val();

    if(passValue != ""){
        $('.empty_pass').addClass('active');
    
    }else{
        $('.empty_pass').removeClass('active');
        count++;
    }
	if(passValue.match(/[a-z]/g)){
		$('.Lowercase').addClass('active');
	
	}else{
		$('.Lowercase').removeClass('active');
		count++;
	}
	if(passValue.match(/[A-Z]/g)){
		$('.Captital').addClass('active');
	
	}else{
		$('.Captital').removeClass('active');
		count++;
	}
	if(passValue.match(/[0-9]/g)){
		$('.Number').addClass('active');
	
	}else{
		$('.Number').removeClass('active');
		count++;
	}
	if(passValue.match(/[!@#$%^&*]/g)){
		$('.Special').addClass('active');
	
	}else{
		$('.Special').removeClass('active');
		count++;
	}
	if(passValue.length == 8 || passValue.length > 8 ){
		$('.eight_ch').addClass('active');
	
	}else{
		$('.eight_ch').removeClass('active');
		count++;
	}

	if (count == 0) {
		isSubmitPassRe = true;
	} else {
		isSubmitPassRe = false;
	}
	

  });

//password check
  $('#passwordInput-register-check').on('focus', function(){
	if(!isSubmitCheckPassRe){
		$('.password_required_check').slideDown();
	}
	
  })

  $('#passwordInput-register-check').on('blur', function(e){
	  if(isSubmitCheckPassRe){
		  $('.password_required_check').slideUp();
	  }
		
  })

  $('#passwordInput-register-check').on('keyup', function(){
	let count = 0;
	passCheckValue = $(this).val();
	
  
    if(passCheckValue != ""){
        $('.empty').addClass('active');
    
    }else{
        $('.empty').removeClass('active');
        count++;
    }
	if(passCheckValue == passValue && passCheckValue != ""){
        $('.check').addClass('active');
    
    } else {
        $('.check').removeClass('active');
        count++;
    }

	if (count == 0) {
		isSubmitCheckPassRe = true;
	} else {
		isSubmitCheckPassRe = false;
	}
  });




