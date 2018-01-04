
//表单简单验证
jQuery(document).ready(function () {

    //$('#submit').click(function () {
    //    FormSubmitHandler();
    //});

    $('.page-container form .username, .page-container form .password').keyup(function () {
        $(this).parent().find('span').fadeOut('fast');
    });


});

//表单提交处理
function FormSubmitHandler()
{
    var username = $("#login").find('.username').val();
    var password = $("#login").find('.password').val();
    if (username == '') {
        $(".error1").text("用户名不能为空");
        $(".error1").fadeIn();
        $(".username").focus();
        return false;
    }else if (password == '') {
        $(".error2").text("密码不能为空");
        $(".error2").fadeIn();
        $(".password").focus();
        return false;
    }
     else {
        //$.ajax({
        //    url: "Login",
        //    type:"post",
        //    data: "username=" + username+"&password="+password,
        //    dataType:"json",
        //    success: function (message) {
        //        //处理提交成功
        //        LoginHandler(message);
        //    },
        //    fail:function (){
        //        alert("提交失败，请检查网络！");
        //    },
        //    error: function () {
        //        alert("提交错误，请稍后重试！");
        //    }               
        //});

        window.location.href = "Login?username=" + username + "&password="+password;
        return false;
    }
}

//处理登陆后返回的信息
function LoginHandler(message) {
    switch(message.message)
    {
        case "ParameterError":
            alert("提交数据有误！");
            break;
        case "NoData":
            alert("用户不存在！");
            break;
        case "PwdWrong":
            alert("密码错误！");
            break;
    }

}

///supersized初始化
jQuery(function ($) {

    $(".username").focus();

    $.supersized({

        // Functionality
        slide_interval: 4000,    // Length between transitions
        transition: 1,    // 0-None, 1-Fade, 2-Slide Top, 3-Slide Right, 4-Slide Bottom, 5-Slide Left, 6-Carousel Right, 7-Carousel Left
        transition_speed: 1000,    // Speed of transition
        performance: 1,    // 0-Normal, 1-Hybrid speed/quality, 2-Optimizes image quality, 3-Optimizes transition speed // (Only works for Firefox/IE, not Webkit)

        // Size & Position
        min_width: 0,    // Min width allowed (in pixels)
        min_height: 0,    // Min height allowed (in pixels)
        vertical_center: 1,    // Vertically center background
        horizontal_center: 1,    // Horizontally center background
        fit_always: 0,    // Image will never exceed browser width or height (Ignores min. dimensions)
        fit_portrait: 1,    // Portrait images will not exceed browser height
        fit_landscape: 0,    // Landscape images will not exceed browser width

        // Components
        slide_links: 'blank',    // Individual links for each slide (Options: false, 'num', 'name', 'blank')
        slides: [    // Slideshow Images
                                 { image: '../img/bg/bg01.jpg' },
                                 { image: '../img/bg/bg02.jpg' },
                                 { image: '../img/bg/bg03.jpg' }
        ]

    });

});


