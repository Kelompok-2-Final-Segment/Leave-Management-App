function simplyDateTime(dateTime) {
    dateTime = dateTime.slice(0, 10);

    let split = dateTime.split('-');

    return `${split[2]}-${split[1]}-${split[0]}`;
}