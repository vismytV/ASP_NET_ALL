function pokaz_menu(id_tr, id_frame = "net") {
	if (document.getElementById(id_tr).style.display == "none") {
		document.getElementById(id_tr).style.display = "table-row";
		scrollToElement(id_tr);

		if (id_frame == "pokaz_all_avto") {
			let currentUrl = window.location.href + "car";
			document.getElementById('url_all').innerHTML = currentUrl;
			document.getElementById(id_frame).src = currentUrl;
		}
	}
	else {
		document.getElementById('url_kol').innerHTML = "";
		document.getElementById('url_all').innerHTML = "";

		if (id_frame != "net") {
			document.getElementById(id_frame).src = "";
		}

		if (id_tr == "new_avto") {
			document.getElementById('Brand').value = "";
			document.getElementById('Model').value = "";
			document.getElementById('Color').value = "";
			document.getElementById('Year').value = "";
		}

		if (id_tr == "info_kol_avto") {
			document.getElementById('startNom').value = "";
			document.getElementById('kol').value = "";
		}

		if (id_tr == "edit_avto") {
			document.getElementById('Id_poisk').value = "";
			document.getElementById('Brand_poisk').value = "";
			document.getElementById('Model_poisk').value = "";
			document.getElementById('Color_poisk').value = "";
			document.getElementById('Year_poisk').value = "";
		}

		document.getElementById(id_tr).style.display = "none";
	}
}


function info_kol_avto1() {

	let start_nom = document.getElementById('startNom').value;
	let kol = document.getElementById('kol').value;
	let a = Number(start_nom); let b = Number(kol);

	if (a <= 0) { a = 0; start_nom = "0"; }
	if (b <= a) { kol = "1"; }

	let currentUrl = window.location.href + "car?startNom=" + start_nom + "&kol=" + kol;
	document.getElementById('pokaz_kol_avto').src = currentUrl;
	document.getElementById('url_kol').innerHTML = currentUrl;


}

function edit_avto1(metod, nazad) {


	if (metod == "PUT") {
		//alert('на стадії розробки'); return;//не перереходе по PUT
		real_id = document.getElementById('Id_poisk').value;


	}
	else {
		real_id = document.getElementById('Id_poisk_del').value;
	}

	adr = window.location.origin + "/car/" + real_id;


	//alert(adr);

	const formData = {
		Id: real_id,
		Brand: document.getElementById('Brand_poisk').value,
		Model: document.getElementById('Model_poisk').value,
		Color: document.getElementById('Color_poisk').value,
		Year: parseInt(document.getElementById('Year_poisk').value, 10), // Преобразуем в число
	};

	fetch(adr, {
		method: metod,
		body: JSON.stringify(formData), // используем данные в правильном формате
		headers: {
			'Content-Type': 'application/json',
		},
	})
		.then(response => {
			if (response.ok) {
				//alert('Successfully updated!');
			} else {
				response.text().then(text => {
					console.log('Response status:', response.status);
					console.log('Response body:', text);
					//alert('Failed to update: ' + text);
				});
			}
		})
		.catch(error => {
			console.log('Fetch error:', error);
			//alert('Error: ' + error.message);
		});

	pokaz_menu(nazad);
}

function scrollToElement(id) {
	var element = document.getElementById(id);

	element.scrollIntoView({
		behavior: "smooth",  // Плавная прокрутка
		block: "center",     // Вертикальное выравнивание: "start", "center", "end"
		//inline: "nearest"    // Горизонтальное выравнивание
	});

}

function razmer(nazva, id) {
	str_src = document.getElementById(id).src;
	if (str_src.indexOf('min.png') != -1) {
		document.getElementById(id).src = "/img/max.png";
		q = 1;
	}
	else {
		document.getElementById(id).src = "/img/min.png";
		q = 0;
	}

	for (i = 1; i <= 2;i++) {
		nazva1 = nazva + "_" + i;
		if (q == 1) {
			document.getElementById(nazva1).style.display = "none";
		}
		else {
			document.getElementById(nazva1).style.display = "block";
		}
		
	}
}

function ris_cursor() {
	
}