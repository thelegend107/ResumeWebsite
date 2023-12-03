import MD5 from "crypto-js/md5";
const monthNames = ["JAN", "FEB", "MAR", "APR", "MAY", "JUNE", "JULY", "AUG", "SEPT", "OCT", "NOV", "DEC"];

export function displayAddress(obj) {
    let addressArray = [];
/*     if (obj.address1)
        addressArray.push(obj.address1); */
    if (obj.address2)
        addressArray.push(obj.address2);
    if (obj.city || obj.state)
        addressArray.push((obj.city + " " + obj.state.stateCode).trim());
    if (obj.country)
        addressArray.push(obj.country.ISO2);

    return addressArray.join(', ')
}

export function displayDate(string) {
    let displayDate = ""

    const date = new Date(string);
    const month = date.getMonth();
    const year = date.getFullYear();
    
    displayDate += monthNames[month] + " " + year;

    return displayDate;
}

export async function getUserInfo() {
    const response = await fetch('/.auth/me');
    const payload = await response.json();
    const { clientPrincipal } = payload;
    return clientPrincipal;
}

// Get Profile Pic based on Gravatar
export function getGravatarProfilePic(email, size=250) {
    let baseUrl = "https://gravatar.com/avatar/" 
    let emailHash = MD5(email);

    let url = baseUrl + emailHash + "?size=" + size;
    return url
}