var Polylines = [];
var Markers = [];
var Circles = [];
var Rectangles = [];
var Polygons = [];
var seno = 0;
var cosseno = 0;
var tangente = 0;
var center = { lat: -27.635424331918777, lng: -54.13765009492636 };
var last_marker = center;
var width = 15;
var zoom = 18;
var map =  new google.maps.Map(document.getElementById('map'), {
    zoom: zoom,
    center: center, //new google.maps.LatLng(-27.635424331918777, -54.13765009492636),
    mapTypeId: google.maps.MapTypeId.SATELLITE
});

function addPolyline(p1, p2) {
    var line = new google.maps.Polyline({
        map: map,
        path: [p1, p2],
        geodesic: true,
        strokeColor: 'red',
        strokeOpacity: 1,
        strokeWeight: 2
    });
    Polylines.push(line);
}

function addMarker(p) {
    var marker = new google.maps.Marker({
        map: map,
        position: p,
    });
    Markers.push(marker);
}


function addCircle(p) {
    var circle = new google.maps.Circle({
        map: map,
        strokeColor: 'blue',//'#FF0000',
        strokeOpacity: 0,//0.8,
        strokeWeight: 0,//2,
        fillColor: 'red', //'#FF0000',
        fillOpacity: 0.5,
        center: p,
        radius: width / 2
    });
    Circles.push(circle);
}

function addRectangle(p) {
    var rectangle = new google.maps.Rectangle({
        map: map,
        strokeColor: 'red',
        strokeOpacity: 1,
        strokeWeight: 1,//2,
        fillColor: 'red',
        fillOpacity: 0.5,
        bounds: {
            north: p.lat + dif, //33.685,
            south: p.lat - dif,//33.671,
            east: p.lng + dif / 2,//-116.234,
            west: p.lng - dif / 2//-116.251
        }
    });
    Rectangles.push(rectangle);
}

function addPolygon(p) {
   // addPolyline(last_marker, p);
    //var hipo = distance(last_marker, p);

    //poly.setMap(map);
    var l1 = p.lat - dif;
    var l2 = p.lat + dif;

    var n1 = p.lng - dif;// / 2;
    var n2 = p.lng + dif;// / 2;
    var g = 0;//dif;// * 100;

    var p1 = { lat: l2 - g, lng: n1 - g };
    var p2 = { lat: l2 + g, lng: n2 - g };
    var p3 = { lat: l1 + g, lng: n2 + g };
    var p4 = { lat: l1 - g, lng: n1 + g };
    //addMarker(p2);
    var polygon = new google.maps.Polygon({
        map: map,
        strokeColor: 'red',
        strokeOpacity: 1,
        strokeWeight: 1,
        fillColor: 'red',
        fillOpacity: 0.5,
        paths: [p1, p2, p3, p4]
    });
    Polygons.push(polygon);
}


function clearMarkers() {
    $(Polylines).each(function (index, item) { item.setMap(null); });
    $(Markers).each(function (index, item) { item.setMap(null); });
    $(Circles).each(function (index, item) { item.setMap(null); });
    $(Rectangles).each(function (index, item) { item.setMap(null); });
    $(Polygons).each(function (index, item) { item.setMap(null); });
}

function grau_mtr(grau) {
    var mtr = grau * 111319;
    mtr = Math.round(mtr);
    return mtr;
}

function mtr_grau(mtr) {
    var grau = mtr / 111319;
    return grau;
}

//function distance(p1, p2) {
//    var ca = p1.lat - p2.lat;
//    ca = ca < 0 ? ca * -1 : ca;
//    var co = p1.lng - p2.lng;
//    co = co < 0 ? co * -1 : co;
//    var hip = Math.pow(ca, 2) + Math.pow(co, 2);
//    hip = hip < 0 ? hip * -1 : hip;
//    hip = Math.sqrt(hip);
//     console.log('ca: ' + ca + ', co: ' + co + ', hip: ' + hip);
//    return hip;
//}

function addArea() {

}