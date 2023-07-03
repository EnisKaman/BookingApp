const makeType = document.querySelector('table tbody tr td').textContent;
//Get url
const url = new URL(window.location.href);
//Get the last element from URL path
let id = url.pathname.split('/').pop();
const baseUrl = '/Car/CarsByBrand';
 getCarsByBrand(makeType, baseUrl, id);


async function getCarsByBrand(brand, baseUrl, id) {
    try {
        const response = await fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: `brand=${encodeURIComponent(brand)}&id=${encodeURIComponent(id)}`
        });

        if (response.ok) {
            const data = await response.text();
            document.getElementById("other-cars").innerHTML = data;
            let childrenCount = document.getElementById('other-cars').children.length;
            if (childrenCount == 0) {
                document.querySelector('.suggest-title').style.display = 'none';
            }
            else {
                document.querySelector('.suggest-title').style.display = 'block';
            }
           
        } else {
            console.error('Response error:', response.status);
        }
    } catch (exception) {
        console.error(exception);
    }
}