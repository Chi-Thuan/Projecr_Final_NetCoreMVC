document.addEventListener('DOMContentLoaded', function () {

    const contentEditor = document.querySelector('#content-editor')


    let editor = null
    if (contentEditor) {
        editor = CKEDITOR.replace('content-editor', {
            entities: false,
            allowedContent: true,
            entities_additional: '',
            entities_greek: false,
            entities_latin: false,
        })
    }

    const convertToSlug = (str) => {
        str = str.replace(/^\s+|\s+$/g, ''); // trim
        str = str.toLowerCase();

        // remove accents, swap ñ for n, etc
        var from = 'àáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ·/_,:;';
        var to = 'aaaaaaaaaaaaaaaaaeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyd------';
        for (var i = 0, l = from.length; i < l; i++) {
            str = str.replace(new RegExp(from.charAt(i), 'g'), to.charAt(i));
        }
        str = str.replace(/[^a-z0-9 -]/g, '') // remove invalid chars
            .replace(/\s+/g, '-') // collapse whitespace and replace by -
            .replace(/-+/g, '-'); // collapse dashes

        return str;
    }

    /**
     * PAGE CATEGORY
     */
    let page_category = document.querySelector('.page_create_category')
    if (page_category) {

        // PREVIEW IMAGES
        let btn_thumbnail_category = document.querySelector('#add_img')
        let imgThumbnailTemp = document.querySelector('label.add_thumbnail img')
        function handleChooseImage(event) {
            imgThumbnailTemp.setAttribute('src', URL.createObjectURL(event.target.files[0]))
            imgThumbnailTemp.onload = function () {
                URL.revokeObjectURL(imgThumbnailTemp.src)
            }
        }
        btn_thumbnail_category.addEventListener('change', handleChooseImage)

        //RESET IMAGES
        let btn_reset = page_category.querySelector('#btn_resetForm')

        function handleResetFrom() {
            imgThumbnailTemp.setAttribute('src', 'assets/img/uploads/no_image.jpg')
        }

        btn_reset.addEventListener('click', handleResetFrom)


        // CONVERT SLUG
        let inputName = page_category.querySelector('#txt_name')
        let inputSlug = page_category.querySelector('#txt_slug')

        function handleTxtName() {
            inputSlug.value = convertToSlug(this.value)
        }
        function handleTxtSlug() {
            this.value = convertToSlug(this.value)
        }

        inputName.addEventListener('keyup', handleTxtName)
        inputSlug.addEventListener('keyup', handleTxtSlug)

        // AJAX
        let formArr = page_category.querySelector('form.form-content')

        function handlingSubmit(e) {
            e.preventDefault()
            const fd = new FormData(this)

            let xhr = new XMLHttpRequest()
            xhr.onreadystatechange = () => {
                if (xhr.readyState == XMLHttpRequest.DONE && xhr.status == 200) {
                    const data = JSON.parse(xhr.responseText).data
                    if (data) {
                        console.log(JSON.parse(xhr.responseText))
                        Swal.fire({
                            icon: 'success',
                            title: 'Thêm thành công',
                        })
                    } else {

                        const isExist = JSON.parse(xhr.responseText).isExist
                        if (isExist) {
                            Swal.fire({
                                icon: 'error',
                                title: 'Đã tồn tại!',
                                text: 'Vui lòng nhập thông tin mới!',
                            })
                        } else {
                            console.log(JSON.parse(xhr.responseText))
                            Swal.fire({
                                icon: 'error',
                                title: 'Thêm Thất bại',
                                text: 'Vui lòng điền đầy đủ thông tin!',
                            })
                        }

                    }
                }
            }

            xhr.open(this.getAttribute('method'), this.getAttribute('action'))
            xhr.send(fd)
        }

        formArr.addEventListener('submit', handlingSubmit)
    }

    /**
     * PAGE SUB CATEGORY
     */
    let page_subCategory = document.querySelector('.page_create_Subcategory')
    if (page_subCategory) {

        // PREVIEW IMAGES
        let btn_thumbnail_category = document.querySelector('#add_img')
        let imgThumbnailTemp = document.querySelector('label.add_thumbnail img')
        function handleChooseImage(event) {
            imgThumbnailTemp.setAttribute('src', URL.createObjectURL(event.target.files[0]))
            imgThumbnailTemp.onload = function () {
                URL.revokeObjectURL(imgThumbnailTemp.src)
            }
        }
        btn_thumbnail_category.addEventListener('change', handleChooseImage)

        //RESET IMAGES
        let btn_reset = page_subCategory.querySelector('#btn_resetForm')

        function handleResetFrom() {
            imgThumbnailTemp.setAttribute('src', 'assets/img/uploads/no_image.jpg')
        }

        btn_reset.addEventListener('click', handleResetFrom)


        // CONVERT SLUG
        let inputName = page_subCategory.querySelector('#txt_name')
        let inputSlug = page_subCategory.querySelector('#txt_slug')

        function handleTxtName() {
            inputSlug.value = convertToSlug(this.value)
        }
        function handleTxtSlug() {
            this.value = convertToSlug(this.value)
        }

        inputName.addEventListener('keyup', handleTxtName)
        inputSlug.addEventListener('keyup', handleTxtSlug)

        // AJAX
        let formArr = page_subCategory.querySelector('form.form-content')

        function handlingSubmit(e) {
            e.preventDefault()
            const fd = new FormData(this)

            let xhr = new XMLHttpRequest()
            xhr.onreadystatechange = () => {
                if (xhr.readyState == XMLHttpRequest.DONE && xhr.status == 200) {
                    const data = JSON.parse(xhr.responseText).data
                    if (data) {
                        console.log(JSON.parse(xhr.responseText))
                        Swal.fire({
                            icon: 'success',
                            title: 'Thêm thành công',
                        })
                    } else {
                        const isExist = JSON.parse(xhr.responseText).isExist
                        if (isExist) {
                            Swal.fire({
                                icon: 'error',
                                title: 'Đã tồn tại!',
                                text: 'Vui lòng nhập thông tin mới!',
                            })
                        } else {
                            console.log(JSON.parse(xhr.responseText))
                            Swal.fire({
                                icon: 'error',
                                title: 'Thêm Thất bại',
                                text: 'Vui lòng điền đầy đủ thông tin!',
                            })
                        }
                    }
                }
            }

            xhr.open(this.getAttribute('method'), this.getAttribute('action'))
            xhr.send(fd)
        }

        formArr.addEventListener('submit', handlingSubmit)
    }

    /**
     * PAGE LIST CATEGORY
     */
    let page_listCategory = document.querySelector('.list_category')
    if (page_listCategory) {
        let listBtnRemoveCategory = page_listCategory.querySelectorAll('.btn_remove_category')

        function handleRemoveCategory(e) {
            e.preventDefault()

            const _id = this.dataset.idcategory

            Swal.fire({
                title: `Xóa danh mục và tất cả sản phẩm kèm theo?`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                cancelButtonText: 'Hủy bỏ',
                confirmButtonText: 'Đồng ý xóa'
            }).then((result) => {

                if (result.isConfirmed) {
                    const xhr = new XMLHttpRequest()
                    xhr.onreadystatechange = function () {
                        if (xhr.readyState == XMLHttpRequest.DONE && xhr.status == 200) {
                            const data = JSON.parse(xhr.responseText).data
                            if (data) {
                                Swal.fire({
                                    title: 'Xóa thành công',
                                    icon: 'success',
                                    showConfirmButton: true,
                                    confirmButtonText: 'OK'
                                })

                                setTimeout(() => {
                                    window.location.reload()
                                }, 1200);
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Xóa thất bại',
                                    text: 'Vui lòng tải lại trang và thử lại!',
                                })
                            }
                        }
                    }
                    xhr.open('POST', `/api/admin/remove-category/${_id}`)
                    xhr.send()
                }
            })
        }

        listBtnRemoveCategory.forEach(btn => {
            btn.addEventListener('click', handleRemoveCategory)
        })

    }

    /**
     * PAGE CREATE PRODUCT
     */
    let page_createProduct = document.querySelector('.create_product')
    if (page_createProduct) {
        // PREVIEW IMAGES
        let btn_thumbnail_category = page_createProduct.querySelector('#add_img')
        let imgThumbnailTemp = page_createProduct.querySelector('label.add_thumbnail img')
        function handleChooseImage(event) {
            imgThumbnailTemp.setAttribute('src', URL.createObjectURL(event.target.files[0]))
            imgThumbnailTemp.onload = function () {
                URL.revokeObjectURL(imgThumbnailTemp.src)
            }
        }
        btn_thumbnail_category.addEventListener('change', handleChooseImage)

        //RESET IMAGES
        let btn_reset = page_createProduct.querySelector('#btn_resetForm')

        function handleResetFrom() {
            imgThumbnailTemp.setAttribute('src', 'assets/img/uploads/no_image.jpg')
        }

        btn_reset.addEventListener('click', handleResetFrom)


        // CONVERT SLUG
        let inputName = page_createProduct.querySelector('#txt_name')
        let inputSlug = page_createProduct.querySelector('#txt_slug')

        function handleTxtName() {
            inputSlug.value = convertToSlug(this.value)
        }
        function handleTxtSlug() {
            this.value = convertToSlug(this.value)
        }

        inputName.addEventListener('keyup', handleTxtName)
        inputSlug.addEventListener('keyup', handleTxtSlug)

        // CHANGE CATEGORY
        let chooseParentCategory = page_createProduct.querySelector('#parentCategory')
        let subCategory = page_createProduct.querySelector('#subCategory')

        function handleChangeCategory() {
            const _id = this.value
            const xhr = new XMLHttpRequest()
            xhr.onreadystatechange = function () {
                if (xhr.readyState == XMLHttpRequest.DONE && xhr.status == 200) {
                    const { data } = JSON.parse(xhr.responseText)
                    subCategory.innerHTML = `<option value="0">Khác</option>`
                    data.forEach(item => {
                        subCategory.innerHTML += `<option value="${item._id}">${item.name}</option>`
                    })
                }
            }
            xhr.open('GET', `/api/admin/render-subCategory-form-category/${_id}`)
            xhr.send()
        }
        chooseParentCategory.addEventListener('change', handleChangeCategory)


        // AJAX
        let formArr = page_createProduct.querySelector('form.form-content')

        function handlingSubmit(e) {
            e.preventDefault()
            const fd = new FormData(this)
            if (this.querySelector('#content-editor')) {
                fd.set('description', editor.getData()/* .replace(/(\<div.+?\>|\<\/div\>)/g, '') */)
            }
            let xhr = new XMLHttpRequest()
            xhr.onreadystatechange = () => {
                if (xhr.readyState == XMLHttpRequest.DONE && xhr.status == 200) {
                    const { data, message } = JSON.parse(xhr.responseText)
                    if (data) {
                        console.log(JSON.parse(xhr.responseText))
                        Swal.fire({
                            icon: 'success',
                            title: message,
                        })
                    } else {
                        const typeError = JSON.parse(xhr.responseText).type

                        switch (typeError) {
                            case 'category':
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Chưa chọn danh mục!',
                                })
                                break;
                            case 'isExist':
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Sản phẩm đã tồn tại!',
                                })
                                break;
                            case 'image':
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Chưa chọn ảnh sản phẩm!',
                                })
                                break;
                            default:
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Lỗi',
                                    text: 'Lỗi ở một nơi xa xôi nào đấy rồi :(((',
                                })
                                break;
                        }
                    }
                }
            }

            xhr.open(this.getAttribute('method'), this.getAttribute('action'))
            xhr.send(fd)
        }

        formArr.addEventListener('submit', handlingSubmit)
    }

    let page_dashboard = document.querySelector('.dashboard')
    if (page_dashboard) {
        let listBtnRemoveItem = page_dashboard.querySelectorAll('.btn_remove_item')

        function handleRemoveCategory(e) {
            e.preventDefault()

            const _id = this.dataset.id

            Swal.fire({
                title: `Bạn có chắc muốn xóa sản phẩm này?`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                cancelButtonText: 'Hủy bỏ',
                confirmButtonText: 'Đồng ý xóa'
            }).then((result) => {

                if (result.isConfirmed) {
                    const xhr = new XMLHttpRequest()
                    xhr.onreadystatechange = function () {
                        if (xhr.readyState == XMLHttpRequest.DONE && xhr.status == 200) {
                            const data = JSON.parse(xhr.responseText).data
                            if (data) {
                                Swal.fire({
                                    title: 'Xóa thành công',
                                    icon: 'success',
                                    showConfirmButton: true,
                                    confirmButtonText: 'OK'
                                })

                                setTimeout(() => {
                                    window.location.reload()
                                }, 1200);
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Xóa thất bại',
                                    text: 'Vui lòng tải lại trang và thử lại!',
                                })
                            }
                        }
                    }
                    xhr.open('POST', `/api/admin/remove-product/${_id}`)
                    xhr.send()
                }
            })
        }

        listBtnRemoveItem.forEach(btn => {
            btn.addEventListener('click', handleRemoveCategory)
        })

    }
})