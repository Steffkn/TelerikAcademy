// You are given an integer array arr, consisting of N integers. Find the number of non-decreasing consecutive subsequences in arr. Every sequence starts after the previous one. 
function Solve(params) {
    var N = parseInt(params[0]);
    var answer = 1;
    var last = parseInt(params[1]);
    for (var i = 2; i <= N; i++) {
        var current = parseInt(params[i]);
        if (current < last) {
            count++;
        }
        last = current;
    }
    return answer;
}
