declare var $: any;

class PizzaController {
    constructor() {
        $(".row.pizzas").on("click", ".btn.btn-primary.detail",  (evt) =>{
            let id =$(evt.target).attr("data-id");
            this.getDetails(id);
            
        })

    }

    getDetails(id: Number): void {
        $.get(`/Pizza/Detail/${id}`)
            .then(function (data) {
                $(".container-modal").html(data);
                $('#modalPizza').modal('show');
            });
    }
}

var pizzaCtrl = new PizzaController();