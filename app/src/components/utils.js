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