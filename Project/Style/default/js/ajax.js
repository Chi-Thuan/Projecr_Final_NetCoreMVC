window.addEventListener('DOMContentLoaded', (event) => {
    let wrap_login = document.querySelector('.wrap_login_register')
    if (wrap_login) {
        let form_login = wrap_login.querySelector('.form_account.login form')
        let form_register = wrap_login.querySelector('.form_account.register form')

        let input_FullnameRegister = form_register.querySelector('input[name="fullname"]')
        let input_Emailregister = form_register.querySelector('input[name="email"]')
        let input_PassRegister = form_register.querySelector('input[name="password"]')
        let input_RePassRegister = form_register.querySelector('input[name="rePassword"]')

        function handleLogin(e) {
            e.preventDefault()
        }

        function handleRegister(e) {
            e.preventDefault()
            let txt_PassRegister = input_PassRegister.value;
            let txt_RePassRegister = input_RePassRegister.value;
            let txt_FullnameRegister = input_FullnameRegister.value;
            let txt_Emailregister = input_Emailregister.value;

            if (txt_PassRegister !== txt_RePassRegister) {
                Swal.fire({
                    icon: 'error',
                    title: 'Lỗi',
                    text: 'Mật khẩu không khớp!',
                })
            } else {
                const BASE_URL = "https://localhost:44308/"
                const url = this.dataset.api
                const api = BASE_URL + url

                var formData = new FormData();



                let user = {
                    fullname: txt_FullnameRegister,
                    email: txt_Emailregister,
                    password: txt_PassRegister
                }
                // Object.keys(user).forEach(item => {
                //     formData.append(item, user[item])
                //  })

                formData.append("productData", "saasncjabsjcb aschasicnas c");

                for (var p of formData) {
                    console.log(p);
                }

                const xhr = new XMLHttpRequest()

                xhr.onreadystatechange = () => {
                    if (xhr.readyState == XMLHttpRequest.DONE) {
                        const res = JSON.parse(xhr.responseText);
                        console.log('data ====  ', res)
                    }
                }

                xhr.open(this.method, api)
                xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
                xhr.send(formData);
            }
        }

        form_login.addEventListener('submit', handleLogin)
        form_register.addEventListener('submit', handleRegister)

    }
});
