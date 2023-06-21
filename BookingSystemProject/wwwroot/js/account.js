let inputElements = document.querySelectorAll("input").forEach((input) => {
    input.addEventListener("focus", (event) => event.target.parentElement.children[0].classList.add("shift"));
    input.addEventListener("blur", () => event.target.parentElement.children[0].classList.remove("shift"));
});
