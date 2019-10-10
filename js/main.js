// Functions for open nav bar click effect, top open new sub menu below

function openNav() {
    $(document).ready(function(){
        $(".openbtn").click(function(){
            // Reveal menu when clicked the menu bar
          $("#reveal-menu").toggleClass("hidden");
          // hide menu when nav away
          $("#reveal-menu").mouseleave(function(){
            $("#reveal-menu").toggleClass("hidden");
        });
        });
      });
}

// function closeNav() {
//     document.getElementById("mySidebar").style.width = "0";
//     document.getElementById("mainNav").style.marginLeft = "0";
// }

// Animated Hamburger Bar

$(document).ready(function () {

    $('.first-button').on('click', function () {
  
      $('.animated-icon1').toggleClass('open');
    });
  });