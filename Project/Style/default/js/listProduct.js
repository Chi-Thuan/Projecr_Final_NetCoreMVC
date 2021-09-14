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
                   
              
                            <div class="col-lg-3 col-sm-3 col-md-3 product_item_new" id="detail_eachproduct" style="padding : 0 !important">
                              <div class="py-5 px-4">
                              <a href="https://localhost:44342/Product/Index/`+ item.id + `">
                                <img class="thumbnail" src="/Style/default/img/images/`+ item.slug +`.jpg" style="width: 100%; height : 200px;object-fit:contain; border-radius : 10px">
                               <a/>

       
                               <p class="name"><a href="https://localhost:44342/Product/Index/`+ item.id + `" class="productDetail">` + item.name +`</a> </p>
                                <p class="price">`+ item.price +`VND</p>
                            
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