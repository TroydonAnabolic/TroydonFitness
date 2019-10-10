// Toggle search bar
$(document).ready(function () {
    $(".fa-search").mouseenter(function () {
        $("input").toggleClass("hidden");
    });
    $("input").mouseleave(function () {
        $("input").toggleClass("hidden");
    });
});

// Functions for open nav bar click effect, top open new sub menu below


    // $(document).ready(function(){
    //       $(".dropdown-menu").mouseleave(function(){
    //         $(".dropdown-menu").toggle();
    //     });
    //     $("button").mouseenter(function(){
    //         $(".dropdown-menu").toggle();
    //     });
      
    //   });

     
        



// function closeNav() {
//     document.getElementById("mySidebar").style.width = "0";
//     document.getElementById("mainNav").style.marginLeft = "0";
// }

// Animated Hamburger Bar

