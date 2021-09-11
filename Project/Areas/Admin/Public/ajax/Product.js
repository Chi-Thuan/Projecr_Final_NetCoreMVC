

function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
              $(previewImage).attr('src',e.target.result);
         }
        reader.readAsDataURL(imageUploader.files[0]);
        }
}

function addProductContent() {
    $.get("/admin/product/createproduct", function (data) {
        $("#content-admin").children().remove();
        $("#content-admin").append(data);
    });
}

function uploadImg() {
    var fileUpload = $("#add_img").get(0);
    var files = fileUpload.files;

    // Create FormData object  
    var fileData = new FormData();

    // Looping over all files and add it to FormData object  
    for (var i = 0; i < files.length; i++) {
        fileData.append(files[i].name, files[i]);
    }

    $.ajax({
        url: '/admin/product/AddProduct',
        type: "POST",
        contentType: false, // Not to set any content header  
        processData: false, // Not to process data  
        data: fileData,
        success: function (result) {
            $("#content-admin").children().remove();
            $("#content-admin").append(result);
            loadNumOfPageProduct();
        },
        error: function (err) {
            alert(err.statusText);
        }
    });
}


function DeleteProduct(id) {
    var url = "https://localhost:44308/delete-product/" + id;
    $.ajax({

        url: url,
        contentType: "application/json",
        dataType: "json",
        type: "Post",
        success: function (result) {
            if (result === true) {
                alert('xóa thành công');
                transToPageListProduct(1);
                return;
            }
            alert('Sẩn phẩm này không thể xóa');
            return;
        },
        error: function (msg) {
            alert('Thao tác thất bại');
        }
    });
  
}

function checkValidateInputProduct() {
    var nameProduct = document.getElementById("txt_name").value;
    var price = document.getElementById("input-price").value;
    var category = jQuery("select#category").val()
    var quantity = document.getElementById("input-quantity").value;
    var des = jQuery("textarea#content-description").val();
    if (nameProduct == null || nameProduct == "") {
        alert("Vui lòng nhập tên sản phẩm");
        document.getElementById("txt_name").focus();
        return false;
    }
    if (add_img.files[0] === undefined) {
        alert("Vui lòng chọn ảnh sản phẩm");
        document.getElementById("previewImage").focus();
        return false;
    }

    if (price == null || price == "") {
        alert("Vui lòng nhập giá tiền");
        document.getElementById("input-price").focus();
        return false;
    }
    if (quantity == null || quantity == "") {
        alert("Vui lòng nhập số lượng");
        document.getElementById("input-price").focus();
        return false;
    }
    if (des == null || des == "") {
        alert("Vui lòng nhập mô tả chi tiết sản phẩm");
        document.getElementById("content-description").focus();
        return false;
    }
    if (category == null || category == "") {
        alert("Vui lòng chọn thể loại sản phẩm");
        document.getElementById("category").focus();
        return false;
    }
    return true;
}

function transToPageListProduct(page) {
    $.get("/admin/product/listproduct",
        { "page": page },
        function (data) {
            console.log(data)
          $("#content-admin").children().remove();
          $("#content-admin").append(data);
            loadNumOfPageProduct();
    });
}


function addProductAPI() {
    // kiểm tra lỗi trước khi xử lý back end. nếu ok thì gửi data vào api
    if (checkValidateInputProduct()) {
        // tạo data truyền vô body
    var product = {};
    product.id = '';
    product.name = document.getElementById("txt_name").value;
    product.slug = null;
    product.thumbnail = '/Content/img/' + add_img.files[0].name;
    product.price = document.getElementById("input-price").value;
    product.category = jQuery("select#category").val();
    product.sub_category = null;
    product.description = jQuery("textarea#content-description").val();;
    product.quantity = document.getElementById("input-quantity").value;
    product.createAt = null;
    product.modifyAt = null;
    product.SubCategory = null;

    $.ajax({
        url: "https://localhost:44308/add-product",
        contentType: "application/json",
        dataType: "json",
        type: "Post",
        data: JSON.stringify(product) ,
        success: function (result) {
            if (result === true) {
                alert('Thêm thành công');
                uploadImg();
                return;
            }
            alert('Thao tác thất bại!! vui lòng thử lại');
            return;
        },
        error: function (msg) {
            alert('Thêm sản phẩm thất bại, vui lòng thử lại');
            return;
        }
    });
    }
}

function tranToPageUpdateProduct(id) {
    $.get("/admin/product/UpdateProduct",
        { "id": id },
        function (data) {
            console.log(data)
            $("#content-admin").children().remove();
            $("#content-admin").append(data);
        });
}

function updateProductAPI() {
        // lay data
        var nameProduct = document.getElementById("txt_name").value;
        var createAt = document.getElementById("txt_modifierDate").value;
        var id = document.getElementById("txt_id").value;
        var price = document.getElementById("input-price").value;
        var category = jQuery("select#category").val()
        var thumnail = add_img.files[0] == undefined ? $('#previewImage').attr('src') : add_img.files[0].name;
        var quantity = document.getElementById("input-quantity").value;
        var des = jQuery("textarea#content-description").val();
        var product = {};
        product.id = id;
        product.name = nameProduct;
        product.slug = null;
        product.thumbnail = '/Content/img/' + thumnail;
        product.price = price;
        product.category = category;
        product.sub_category = null;
        product.description = des;
        product.quantity = quantity;
        product.createAt = createAt;
        product.modifyAt = null;
        product.SubCategory = null;

    $.ajax({
        url: "https://localhost:44308/update-product",
        contentType: "application/json",
        dataType: "json",
        type: "Post",
        data: JSON.stringify(product),
        success: function (result) {
            if (result === true) {
                alert('cập nhật sản phẩm thành công');
                // upload ảnh
                if (add_img.files[0] != undefined) {
                    uploadImg();
                    return
                } else {
                    transToPageListProduct(1);
                    return
                }
              
            }
            alert('Thao tác thất bại!! vui lòng thử lại');
            return;
        },
        error: function (msg) {
            alert('cập nhật sản phẩm thất bại, vui lòng thử lại');
            return;
        }
    });
}

