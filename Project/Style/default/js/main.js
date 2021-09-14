const formLogin = document.querySelector('.form_account.login form');
const formRegister = document.querySelector('.form_account.register form');
if (formLogin) {
    let inputEmail = formLogin.querySelector('input[name="email"]');
    let inputPassword = formLogin.querySelector('input[name="password"]');
    $('.form_account.login form').submit(function (e) {
        e.preventDefault();
    })
    $('.form_account.register form').submit(function (e) {
        e.preventDefault();
    })

    function validateEmail(email) {
        const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }

    $('input#submitFormLogin').click(function (e) {
        let txtEmail = inputEmail.value
        let txtPassword = inputPassword.value

        console.log('txtEmail  ', txtEmail)
        console.log('txtPassword  ', txtPassword)

        if (txtEmail.length == 0 || txtPassword.length == 0) {
            Swal.fire({
                icon: 'error',
                title: 'Vui lòng điền đầy đủ thông tin',
            })
        } else if (!validateEmail(txtEmail)) {
            Swal.fire({
                icon: 'error',
                title: 'Sai định dạng Email',
            })
        } else {
            $.ajax({
                url: "https://localhost:44308/login",
                method: "POST",
                contentType: "application/x-www-form-urlencoded",
                dataType: "json",
                data: {
                    email: txtEmail,
                    password: txtPassword
                },

                success: function (respon) {
                    console.log(respon)
                    if (!respon.error) {
                        console.log(respon)
                        Swal.fire({
                            icon: 'success',
                            title: 'Đăng nhập thành công',
                            confirmButtonText: 'Đồng ý'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.href = `/home?token=${respon.data.token}`
                            }
                        })
                    } else {
                        console.log(respon)
                        if (respon.message == "notMatchPassword") {
                            Swal.fire({
                                icon: 'error',
                                title: 'Sai mật khẩu!',
                            })
                        } else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Tài khoản không tồn tại!',
                            })
                        }
                    }
                }, fail: function (respon) {
                    console.log('error is : ', respon)
                    Swal.fire({
                        icon: 'error',
                        title: 'Lỗi Đăng nhập',
                    })
                }
            })
        }


    })

    $('input#submitFormRegister').click(function (e) {

        let txtFulllname = $('.form_account.register form input[name="fullname"]').val();
        let txtEmail = $('.form_account.register form input[name="email"]').val();
        let txtPassword = $('.form_account.register form input[name="password"]').val();
        let txtRePassword = $('.form_account.register form input[name="repassword"]').val();

        if (txtFulllname.length == 0 || txtEmail == 0 || txtPassword.length == 0 || txtRePassword.length == 0) {
            Swal.fire({
                icon: 'error',
                title: 'Vui lòng điền đầy đủ thông tin',
            })
        } else if (!validateEmail(txtEmail)) {
            Swal.fire({
                icon: 'error',
                title: 'Sai định dạng Email',
            })
        } else if (txtPassword !== txtRePassword) {
            Swal.fire({
                icon: 'error',
                title: 'Mật khẩu không khớp',
            })
        } else {
            $.ajax({
                url: "https://localhost:44308/registerLocal",
                method: "POST",
                contentType: "application/x-www-form-urlencoded",
                dataType: "json",
                data: {
                    fullname: txtFulllname,
                    email: txtEmail,
                    password: txtPassword
                },

                success: function (respon) {
                    console.log(respon)
                    if (!respon.error) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Đăng ký thành công',
                            confirmButtonText: 'Đồng ý'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.href = `/home?token=${respon.data}`
                            }
                        })
                    } else {
                        if (respon.message == "emailExist") {
                            Swal.fire({
                                icon: 'error',
                                title: 'Email đã tồn tại',
                            })
                        } else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Đăng ký thất bại',
                            })
                        }
                    }
                }, fail: function (respon) {
                    console.log('error is : ', respon)
                    Swal.fire({
                        icon: 'error',
                        title: 'Lỗi Đăng ký',
                    })
                }
            })
        }
    })
}