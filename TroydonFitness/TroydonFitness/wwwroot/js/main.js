// Toggle search bar
$(document).ready(function () {
    $(".fa-search").mouseenter(function () {
        $(".search-input").toggleClass("hidden");
    });
    $(".search-input").mouseleave(function () {
        $(".search-input").toggleClass("hidden");
    });
});

// Get the modal
var modal = document.getElementById("myModal");

// Get the button that opens the modal
var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal 
btn.onclick = function() {
  modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function() {
  modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
   if (event.target == modal) {
    modal.style.display = "none";
  }
}
     
        



// function closeNav() {
//     document.getElementById("mySidebar").style.width = "0";
//     document.getElementById("mainNav").style.marginLeft = "0";
// }

// Animated Hamburger Bar

