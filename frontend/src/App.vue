<template>
  <div id="app">
    <div class="text-center">
      <!-- simple form to input year -->
      <form onsubmit="return false">
        <h1>Vnesi leto za izpis praznikov</h1>
        <input
          style="text-align:center; margin: 0 10px 0 10px; width: 70px;"
          placeholder="YYYY"
          v-model="year"
          type="text"
          @keypress.enter="getHolidaysByYear(year)"
        />
        <input type="submit" @click="getHolidaysByYear(year)" />
      </form>

      <!-- table for displaying data -->
      <table class="holidaysTable">
        <tr>
          <th>Praznik</th>
          <th>Datum</th>
          <th>Dan v tednu</th>
        </tr>
        <tr v-for="item of holidays" :key="item.id">
          <td>{{ item.name }}</td>
          <td>{{ item.day + "." + item.month + "." + item.year }}</td>
          <td>{{ item.weekday }}</td>
        </tr>
      </table>
    </div>
  </div>
</template>

<script>
export default {
  name: "app",
  data() {
    return {
      year: "",
      holidays: [],
    };
  },
  async created() {
    const res = await fetch("https://localhost:5001/api/holidays").then((response) =>
      response.json()
    );
    return (this.holidays = res);
  },
  methods: {
    async getHolidaysByYear(id) {
      const res = await fetch(`https://localhost:5001/api/holidays/${id}`).then((response) =>
        response.json()
      );
      this.year = "";
      return (this.holidays = res);
    },
  },
};
</script>

<style>
html,
body {
  padding: 1rem;
  background-color: #303030;
  color: #fff;
}

.button {
  margin: 10px;
}

.holidaysTable tr td {
  border: 1px solid #fff;
}

.holidaysTable {
  margin-top: 2rem;
  width: 80%;
  margin-left: auto;
  margin-right: auto;
}
</style>
