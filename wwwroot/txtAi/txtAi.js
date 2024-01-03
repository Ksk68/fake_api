document.addEventListener("DOMContentLoaded", function() {
    const btn = document.querySelector("#btn")

    btn.addEventListener("click",function(e){
        e.preventDefault();

        const txt = document.querySelector("#txt")

        const txt_value = txt.value;

        console.log(txt_value)
    });
});