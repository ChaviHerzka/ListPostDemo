$(() => {
    let counter = 1;
    console.log("hello")
    $("#add-button").on("click", function () { 
        $("#ppl-rows").append(`<div class="row" style="margin-bottom: 10px;">
                                <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${counter}].FirstName" placeholder="First Name" />
                                </div>
                                <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${counter}].LastName" placeholder="Last Name" />
                                </div>
                                <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${counter}].Age" placeholder="Age" />
                                </div>
                                </div>`);
        counter++
        console.log(counter)
                               
    });
});
