var array = [9, 2, 5, 6, 4, 73, 3, 7, 10, 1, 8, 44];

// swap function helper
function swap(array, i, j) {
    var temp = array[i];
    array[i] = array[j];
    array[j] = temp;
}

// this is a very basic implementation which is nice to understand the deep principle of bubble sort (going through all comparisons) 
// it can be greatly improved for performances
function bubbleSortBasic(array) {
    for (var i = 0; i < array.length; i++) {
        for (var j = 1; j < array.length; j++) {
            if (array[j - 1] > array[j]) {
                swap(array, j - 1, j);
            }
        }
    }
    return array;
}

function bubbleSortFirstBiggest(array, k) {
    for (var i = 0; i < kgm; i++) {
        for (var j = 1; j < array.length; j++) {
            if (array[j - 1] > array[j]) {
                swap(array, j - 1, j);
            }
        }
    }

    return array.slice(array.length - k - 1, array.length);
}

function convertArrayToString(array) {
    var s = '';
    for (var j = 1; j < array.length; j++) {
        s = s + array[j].toString() + ' ';
    }
    return s;
}


$("#dTitle").html("Bubble sort demo on JavaScipt/JQuery");
$("#divA").html(convertArrayToString(array));
$("#divAsorted").html(convertArrayToString(bubbleSortBasic(array)));
$("#divAsorted2").html(convertArrayToString(bubbleSortFirstBiggest(array, 3)));

