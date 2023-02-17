
    $(document).ready(function() {
      $('.form_error').hide();
      $('#submit').click(function(){
           var name = $('#name').val();
           var email = $('#email').val();
           var phone = $('#phone').val();
           var message = $('#message').val();
           if(name== ''){
              $('#name').next().show();
              return false;
            }
            if(email== ''){
               $('#email').next().show();
               return false;
            }
            if(IsEmail(email)==false){
                $('#invalid_email').show();
                return false;
            }

            if(phone== ''){
                $('#phone').next().show();
                return false;
            }
            if(message== ''){
                $('#message').next().show();
                return false;
            }
            //ajax call php page
            $.post("send.php", $("#contactform").serialize(),  function(response) {
            $('#contactform').fadeOut('slow',function(){
                $('#success').html(response);
                $('#success').fadeIn('slow');
               });
             });
             return false;
          });
      });
      function IsEmail(email) {
        var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        if(!regex.test(email)) {
           return false;
        }else{
           return true;
        }
      }

<form action="" method="post" id="contactform">
                            <table class="contact-table">
                              <tr>
                                <td><label for="name">Name :</label></td>
                                <td class="name"> <input name="name" id="name" type="text" placeholder="Please enter your name" class="contact-input"><span class="form_error">Please enter your name</span></td>
                              </tr>
                              <tr>
                                <td><label for="email">Email :</label></td>
                                <td class="email"><input name="email" id="email" type="text" placeholder="Please enter your email" class="contact-input"><span class="form_error">Please enter your email</span>
                                  <span class="form_error" id="invalid_email">This email is not valid</span></td>
                              </tr>
                              <tr>
                                <td><label for="phone">Phone :</label></td>
                                <td class="phone"><input name="phone" id="phone" type="text" placeholder="Please enter your phone" class="contact-input"><span class="form_error">Please enter your phone</span></td>
                              </tr>
                              <tr>
                                <td><label for="message">Message :</label></td>
                                <td class="message"><textarea name="message" id="message" class="contact-input"></textarea><span class="form_error">Please enter your message</span></td>
                              </tr>
                              <tr>
                                <td></td>
                                <td>
                                  <input type="submit" class="contactform-buttons" id="submit"value="Send" />
                                  <input type="reset" class="contactform-buttons" id="" value="Clear" />
                                </td>
                              </tr>
                            </table>
     </form>
     <div id="success" style="color:red;"></div>