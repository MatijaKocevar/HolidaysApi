<template>
  <div id="app">
    <div class="text-center">
      <!-- simple form to input year -->
      <form method="get">
        <h1>Enter year to get holidays</h1>
        <input type="text" /><br />
        <input type="submit" />
      </form>

      <!-- table for displaying data -->
      <table class="holidaysTable">
        <tr>
          <th>Holiday</th>
          <th>Date</th>
          <th>Weekday</th>
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
const URL = "https://localhost:5001/api/holidays";

export default {
  name: "App",
  data() {
    return {
      holidays: [],
    };
  },
  async mounted() {
    const res = await fetch(URL).then((response) => response.json());
    console.log(res);
    return (this.holidays = res);
  },
};
</script>

<style>
html,
body {
  background-color: #303030;
  color: #fff;
}

.holidaysTable tr td {
  border: 1px solid #fff;
}

.holidaysTable {
  margin-top: 100px;
  width: 80%;
  margin-left: auto;
  margin-right: auto;
}
</style>
