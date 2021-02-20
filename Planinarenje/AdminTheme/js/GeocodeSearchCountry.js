
    let lang = "en";

    const url = 'https://autocomplete.geocoder.ls.hereapi.com/6.2/suggest.json?apiKey=kI9Red6f6Bmm5ummtOtMXgTIbML55lQDCFqpgX2ZgLo';
    const query = '&query=';
    var queryInput = 'Beograd';
    const language = '&language=';
    var queryLanguage = 'en';// for serbian is = 'sr'
    const country = '&country=';
    var queryCountry = 'SRB';
    const restQuery = '&beginHighlight=%3Cb%3E&endHighlight=%3C/b%3E';


        function appendElementToUI(data, ulElement, inputId) {
            var li = document.createElement("li");
            li.setAttribute("class", "autocompleteLi-item");
            li.addEventListener("click", function () {
        document.getElementById(inputId).value = data;
                ulElement.setAttribute("class", "autocompleteClose");
            });
            li.innerHTML = data;

            ulElement.appendChild(li);
        }
        function GetSingleAddress(data) {
            return JSON.stringify(data).replace(/^["'](.+(?=["']$))["']$/, '$1');
        }

        function autocompleteGetPlace(search, id) {

        let invoke = url + query + search + language + lang;
            console.log(invoke);
            let ulAutocompletDisplay = document.getElementById("countryAreaDetection");
            clearDisplay(ulAutocompletDisplay);
            $.get(invoke, function (data, status) {

                if (status == "success") {

        ulAutocompletDisplay.setAttribute("class", "autocompleteDisplay");
                    console.log(JSON.stringify(data));
                    for (let i = 0; i < JSON.stringify({
                        if (JSON.stringify(data["suggestions"][i] != "undefined") && JSON.stringify(data["suggestions"][i] != null)) {

                            if (data["suggestions"][i] != null) {
        let country = GetSingleAddress(data["suggestions"][i].address.country);

                                appendElementToUI(country, ulAutocompletDisplay, id);
                            }
                        }
                    }
                }


            });

        }
        function autocompleteGetCountry(search, id) {

        let invoke = url + query + search + language + lang;
            let ulAutocompletDisplay = document.getElementById("countryAreaDetection");
            clearDisplay(ulAutocompletDisplay);
            $.get(invoke, function (data, status) {

                if (status == "success") {

        ulAutocompletDisplay.setAttribute("class", "autocompleteDisplay");
                    console.log(JSON.stringify(data));
                    for (let i = 0; i < JSON.stringify({
                        if (JSON.stringify(data["suggestions"][i] != "undefined") && JSON.stringify(data["suggestions"][i] != null)) {

                            if (data["suggestions"][i] != null) {
        let country = GetSingleAddress(data["suggestions"][i].address.country);

                                appendElementToUI(country, ulAutocompletDisplay, id);
                            }
                        }
                    }
                }


            });

        }
        function autocompleteGetCityState(search, id) {
        let invoke = url + query + search + language + lang;
            let ulAutocompletDisplay = document.getElementById("stateCountry");
            clearDisplay(ulAutocompletDisplay);
            $.get(invoke, function (data, status) {
                if (status == "success") {
        ulAutocompletDisplay.setAttribute("class", "autocompleteDisplay");

                    for (let i = 0; i < JSON.stringify({

                        if (JSON.stringify(data["suggestions"][i] != "undefined") && JSON.stringify(data["suggestions"][i] != null)) {
        let city = GetSingleAddress(data["suggestions"][i].address.city);

                            if (isNaN(city) || city == 'undefined' || city == null) {
        let state = GetSingleAddress(data["suggestions"][i].address.state);
                                appendElementToUI(state, ulAutocompletDisplay, id);
                            }
                            else {

        appendElementToUI(city, ulAutocompletDisplay, id);
                            }
                        }
                    }

                }

            });

        }
        function autocompleteCountryInit(search, id) {

        // autocompletCountries(search, id);

        SearchArea(search);


            //this can be called for autho complete here maps
            // autocompleteGetCountry(search, id);

        }
        function autocompleteCityStateInit(search, id) {
        autocompleteGetCityState(search, id);
        }
        function changeLanguage(setLanguage) {
        lang = setLanguage;
        }


        function clearDisplay(elemen) {
        elemen.innerHTML = "";
        }
        function autocompletCountries(search, id) {
        let invokeLocalServer = "/Admin/GetCountries";
            let ulAutocompletDisplay = document.getElementById("countryAreaDetection");
            clearDisplay(ulAutocompletDisplay);
            $.post(invokeLocalServer, {Search: search }, function (data, status) {
                if (status == "success") {

                    if (data != null) {
        let result = JSON.parse(data);



                        ulAutocompletDisplay.setAttribute("class", "autocompleteDisplay");
                        for (let i = 0; i < result.length; {
                            if (JSON.stringify(result[i] != "undefined") && result[i] != null) {
        let country = result[i].CountryName;
                                let coorinates = result[i].Coordinates;
                                appendElementToUI(country, ulAutocompletDisplay, id);
                            }
                        }
                    }



                }


            });

        }
