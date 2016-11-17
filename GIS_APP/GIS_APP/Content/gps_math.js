//http://www.movable-type.co.uk/scripts/latlong.html
//Note: angles need to be in radians to pass to trig functions

var R = 6371e3; //earth mean radius in km

//converts degrees to radians
function deg2rad(d) {
    return d * (Math.PI / 180);
}

//converts radians to degrees
function rad2deg(r) {
    return r / (Math.PI / 180);
}

//Distance given two points
function distance(p1, p2) {
    lat1r = deg2rad(p1.lat);
    lat2r = deg2rad(p2.lat);

    x = (p2.lng - p1.lng) * Math.cos((lat1r + lat2r) / 2);
    y = p2.lat - p1.lat;
    return Math.sqrt(x * x + y * y) * deg2rad(R);
}

//Bearing given two points
function bearing(lat1, lon1, lat2, lon2) {
    lat1r = deg2rad(lat1);
    lon1r = deg2rad(lon1);
    lat2r = deg2rad(lat2);
    lon2r = deg2rad(lon2);

    y = Math.sin(lon2r - lon1r) * Math.cos(lat2r);
    x = Math.cos(lat1r) * Math.sin(lat2r) - Math.sin(lat1r) * Math.cos(lat2r) * Math.cos(lon2r - lon1r);

    //return rad2deg(Math.atan2(y, x));
    brng = rad2deg(Math.atan2(y, x));
    if (brng < 0)
        brng += 360;
    return brng;
}

//Destination point given distance and bearing from start point
function dest_point(lat, lon, brng, dist) {
    latr = deg2rad(lat);
    lonr = deg2rad(lon);
    brngr = deg2rad(brng);

    dlat = Math.asin(Math.sin(latr) * Math.cos(dist / R) + Math.cos(latr) * Math.sin(dist / R) * Math.cos(brngr));
    dlon = lonr + Math.atan2(Math.sin(brngr) * Math.sin(dist / R) * Math.cos(latr), Math.cos(dist / R) - Math.sin(latr) * Math.sin(dlat));

    return { lat: rad2deg(dlat), lng: rad2deg(dlon) };
}

//Calculate the four points of a square
function points_of_square(lat1, lon1, lat2, lon2, brng, dist) {
    //brng1 = Math.abs(brng - 90);//fabs(brng - 90);
    brng1 = brng - 90;
    if (brng1 < 0)
        brng1 += 360;
    brng2 = (brng1 + 180) % 360;

    p0 = dest_point(lat1, lon1, brng1, dist);
    p1 = dest_point(lat2, lon2, brng1, dist);
    p2 = dest_point(lat2, lon2, brng2, dist);
    p3 = dest_point(lat1, lon1, brng2, dist);

    return [p0, p1, p2, p3];
}

