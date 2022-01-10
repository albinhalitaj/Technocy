function addToCart(productId) {
    $.ajax({
        type: "POST",
        url: `https://${window.location.host}/cart/add`,
        data: {"productId": productId},
        success: async function (resp) {
            if (resp.success) {
                let count = $('.count-style-3').text(resp.items);
                count.attr('hidden', false);
                let total = $('.mini-cart-price-3').attr('hidden', false);
                total.text(resp.total + "€")

                const Toast = Swal.mixin({
                    toast: true,
                    position: 'top-right',
                    iconColor: 'red',
                    customClass: {
                        popup: 'colored-toast'
                    },
                    showConfirmButton: false,
                    timer: 1500,
                    timerProgressBar: true
                })
                await Toast.fire({
                    icon: 'success',
                    title: 'Produkti u shtua në shportë'
                })
                location.href = "/cart";

            }
        },
        error: function (err) {
            console.error(err);
        }
    })
}    
    