const formLogin = document.querySelector('form#loginAdmin');

if (formLogin) {

    let inputEmail = formLogin.querySelector('input[name="email"]');
    let inputPassword = formLogin.querySelector('input[name="password"]');
    $('form#loginAdmin').submit(function (e) {
        e.preventDefault();
    })

    $('input#submitFormLogin').click(function (e) {
        let txtEmail = inputEmail.value
        let txtPassword = inputPassword.value

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
                    Swal.fire({
                        icon: 'success',
                        title: 'Đăng nhập thành công',
                        confirmButtonText: 'Đồng ý'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            localStorage.setItem('token', 'day la token')
                            window.location.href = `/admin?token=${respon.data.token}`
                        }
                    })
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Đăng nhập thất bại',
                        confirmButtonText: 'Đồng ý'
                    })
                }
            }, fail: function () {
                Swal.fire({
                    icon: 'error',
                    title: 'Lỗi đăng nhập',
                    confirmButtonText: 'Đồng ý'
                })
            }
        })

    })
}

