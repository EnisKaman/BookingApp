const headerElement = document.querySelector("header");
console.log(headerElement);
window.addEventListener("scroll", () => {
    headerElement.classList.toggle("sticky", window.scrollY > 0);
});
