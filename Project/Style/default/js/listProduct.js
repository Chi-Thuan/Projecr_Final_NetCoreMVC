$(document).ready(function () {
    new listJS();


});
class listJS {
    constructor() {
        this.loadData();
    }
    //Load data
    loadData() {
        $.ajax({
            url: "https://localhost:44308/pages/1",
            method: "GET",
            data: "",
            contentType: "application/json",
            dataType: "",
            success: function (response) {
                $(`section.product_list   div.list_prod div.list_prod_row`).empty();
                $.each(response, function (index, item) {
                    var trHTML = $(`
                   
              
                            <div class="col-lg-4 col-sm-4 col-md-4" id="detail_eachproduct">
                              <div style="margin:50px; 0px">
                              <img src="/Style/default/img/images/`+item.slug+`.jpg" width="180" height="150">

       
                               <p> Name:  <a href="https://localhost:44342/Product/Index/`+ item.id + `" class="productDetail">` + item.name +`</a> </p>
                                <p>Price: `+ item.price +`</p>
                            
                             <a href="https://localhost:44342/Cart/cart?status=true&id=`+ item.id + `" class="add_cart">`+ "Add to cart" +`</a></div>
  
</div>`);
                    $(`section.product_list   div.list_prod div.list_prod_row`).append(trHTML);
                })
            },
            fail: function (response) {

            }

        }).done(function (response) {

        }).fail(function (response) {
        })


    }


}