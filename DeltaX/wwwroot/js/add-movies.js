Vue.component('v-select', VueSelect.VueSelect);

var AddMoviesVue = new Vue({
    el: "#add-movies",
    data: {
        movies: [],
        actors: [],
        producers: [],
        poster_preview_url: null,
        new_actor: {
            Name: null,
            Bio: null,
            DateOfBirth: moment(new Date()).format('YYYY-MM-DD'),
            Sex: 0
        },
        new_producer: {
            Name: null,
            Bio: null,
            DateOfBirth: moment(new Date()).format('YYYY-MM-DD'),
            Sex: 0
        },
        new_movie: {
            Name: null,
            Plot: null,
            YearOfRelease: Number(moment(new Date()).format('YYYY')),
            PosterImage: null,
            ProducerId: null,
            ActorIds: []
        },
        is_creating_movie: false,
        is_creating_actor: false,
        is_creating_producer: false,
        gender: [{ "name": "Male", "value": 0 }, { "name": "Female", "value": 1 }]
    },
    created: function () {
        this.GetAllActors();
        this.GetAllProducers();
    },
    methods: {
        GetAllActors: function () {
            var self = this;
            $.ajax({
                url: "/Actor/v1/ListAllActors",
                method: "GET",
                success: function (actor_list) {
                    self.actors = actor_list;
                }
            });
        },
        GetAllProducers: function () {
            var self = this;
            $.ajax({
                url: "/Producer/v1/ListAllProducers",
                method: "GET",
                success: function (producer_list) {
                    self.producers = producer_list;
                    self.new_movie.ProducerId = self.producers[0]._id;
                }
            });
        },

        AddNewMovie: function () {
            var self = this;
            self.is_creating_movie = true;
            $.ajax({
                url: "/Movie/v1/AddNewMovie",
                method: "PUT",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                data: JSON.stringify(self.new_movie),
                success: function (data) {
                    alert("Movie Added");
                    self.is_creating_movie = false;
                },
                error: function (data) {
                    alert("Error, please fill all details correctly")
                    self.is_creating_movie = false;
                }
            });
        },
        AddNewProducer: function () {
            var self = this;
            self.is_creating_producer = true;
            $.ajax({
                url: "/Producer/v1/AddNewProducer",
                method: "PUT",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                data: JSON.stringify(self.new_producer),
                success: function (data) {
                    alert("Producer Added");
                    self.is_creating_producer = false;

                    self.GetAllProducers();
                },
                error: function (data) {
                    alert("Error, please fill all details correctly")
                    self.is_creating_producer = false;
                }
            });
        },

        SetGenderOfPerson: function (gender, person) {
            person.Sex = Number(gender);
        },

        AddNewActor: function () {
            var self = this;
            self.is_creating_actor = true;
            $.ajax({
                url: "/Actor/v1/AddNewActor",
                method: "PUT",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                data: JSON.stringify(self.new_actor),
                success: function (data) {
                    alert("Actor Added");
                    self.is_creating_actor = false;
                    self.GetAllActors();
                },
                error: function (data) {
                    alert("Error, please fill all details correctly")
                    self.is_creating_actor = false;
                }
            });
        },

        AddNewActorsToMovie: function (actor_list) {
            var actor_ids = [];
            actor_list.forEach(function (actor) {
                actor_ids.push(actor._id);
            })
            this.new_movie.ActorIds = actor_ids;
        },
        SelectProducerForMovie: function (producer_id) {
            this.new_movie.ProducerId = producer_id;
        },
        UploadMoviePoster: function (event) {

            var self = this;

            var fileData = event.target.files[0];
            var fileReader = new FileReader();
            fileReader.readAsDataURL(fileData);

            fileReader.onload = function (data) {
                self.poster_preview_url = data.target.result;
                self.new_movie.PosterImage = fileReader.result.split(',')[1];
            }
        }
    }
})