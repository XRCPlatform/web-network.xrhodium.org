/**
 ******************************
 Page Scripts
 ******************************
 */
var dashboardPage = function(peers) {
	
	var total_chart = {
		size:      110,
		animate:   App.is_old_ie ? false : 2000,
		lineWidth: 6,
		lineCap:   'square'
	};
	
	var map = new ol.Map({
        target: 'tracking-map',
        layers: [
          new ol.layer.Tile({
            source: new ol.source.OSM()
          })
        ],
        view: new ol.View({
          center: ol.proj.fromLonLat([0, 25]),
          zoom: 2.5
        })
    });

    var iconStyle = new ol.style.Style({
        image: new ol.style.Icon(({
            anchor: [0.5, 24],
            anchorXUnits: 'fraction',
            anchorYUnits: 'pixels',
            src: '/theme/icon.png?v2'
        }))
    });

    var iconOtherStyle = new ol.style.Style({
        image: new ol.style.Icon(({
            anchor: [0.5, 24],
            anchorXUnits: 'fraction',
            anchorYUnits: 'pixels',
            src: '/theme/icon-other.png?v2'
        }))
    });

	var vectorSource = new ol.source.Vector();

    for (var i = 0; i < peers.length; i++) {
        vectorSource.addFeature(AddMarker(peers[i].lng, peers[i].lat, iconOtherStyle));
    }

    vectorSource.addFeature(AddMarker(2.352222, 48.856613, iconStyle));
    vectorSource.addFeature(AddMarker(8.682127, 50.110924, iconStyle));
    vectorSource.addFeature(AddMarker(4.890660, 52.373169, iconStyle));
    vectorSource.addFeature(AddMarker(4.830660, 52.323169, iconStyle));
    vectorSource.addFeature(AddMarker(4.830660, 52.423169, iconStyle));
    vectorSource.addFeature(AddMarker(4.950660, 52.323169, iconStyle));
    vectorSource.addFeature(AddMarker(4.950660, 52.423169, iconStyle));
    vectorSource.addFeature(AddMarker(-118.243683, 34.052235, iconStyle));
    vectorSource.addFeature(AddMarker(37.517298, 55.705825, iconStyle));
    vectorSource.addFeature(AddMarker(37.517298, 55.805825, iconStyle));
    vectorSource.addFeature(AddMarker(37.717298, 55.705825, iconStyle));
    vectorSource.addFeature(AddMarker(37.717298, 55.805825, iconStyle));
    vectorSource.addFeature(AddMarker(37.517298, 55.605825, iconStyle));
    vectorSource.addFeature(AddMarker(37.717298, 55.605825, iconStyle));
    vectorSource.addFeature(AddMarker(21.012230, 52.229675, iconStyle));
    vectorSource.addFeature(AddMarker(21.012230, 52.169675, iconStyle));
    vectorSource.addFeature(AddMarker(21.012230, 52.289675, iconStyle));
    vectorSource.addFeature(AddMarker(-73.549133, 52.939915, iconStyle));
    vectorSource.addFeature(AddMarker(30.516670, 50.433330, iconStyle));

	var markerVectorLayer = new ol.layer.Vector({
		source: vectorSource
	});
	map.addLayer(markerVectorLayer);

    $(document).ready(function() {
        App.closeLoading();
		
		$('#cn-accept-cookie').click(function() {
			setCookie('accept-cookie', 'true');
			$('#cookie-notice').removeClass('cookie-notice-visible').addClass('cookie-notice-hidden');
		});
	
		var acceptcookie = getCookie('accept-cookie');
		if (acceptcookie == 'true') {
			$('#cookie-notice').removeClass('cookie-notice-visible').addClass('cookie-notice-hidden');
		}
		
		$('#cn-decline-cookie').click(function() {
			window['ga-disable-G-9RGSLHRKDR'] = true;
			if (window.ga) window.ga('remove');
			if (document.cookie) {
				var cookies = document.cookie.split(";");

				for (var i = 0; i < cookies.length; i++) {
					var cookie = cookies[i];
					var eqPos = cookie.indexOf("=");
					var name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
					var domain = document.domain;
					document.cookie = name + "=;path=/;domain=" + domain + ";expires=Thu, 01 Jan 1970 00:00:00 GMT";
					
				}
			}
			alert("Cookies have been removed.");
		});
    });	
};

function AddMarker(lat, lng, style) {
	var feature = new ol.Feature({
		geometry: new ol.geom.Point(
		ol.proj.fromLonLat([lat, lng])
		),  
    });
    feature.setStyle(style);

    return feature;
}

		function setCookie(key, value) {
			var expires = new Date();
			expires.setTime(expires.getTime() + 31536000000); 
			document.cookie = key + '=' + value + ';expires=' + expires.toUTCString();
		}

		function getCookie(key) {
			var keyValue = document.cookie.match('(^|;) ?' + key + '=([^;]*)(;|$)');
			return keyValue ? keyValue[2] : null;
		}  eyValue = document.cookie.match('(^|;) ?' + key + '=([^;]*)(;|$)');
			return keyValue ? keyValue[2] : null;
		}  