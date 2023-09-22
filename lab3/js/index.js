window.addEventListener('DOMContentLoaded', ()=> {
  function toggleMenu() {
    document.querySelector(".burger").classList.toggle("burger-open");
    document.querySelector(".menu").classList.toggle("menu-open");
    document.body.style.overflow === ""
      ? (document.body.style.overflow = "hidden")
      : (document.body.style.overflow = "");
  }

  document.querySelector(".burger").addEventListener("click", toggleMenu);
});