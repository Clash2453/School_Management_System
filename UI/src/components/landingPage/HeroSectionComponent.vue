<script></script>

<template>
  <section id="hero">
    <div class="heading-wrapper">
      <h1 class="main-title">Digital information system for schools and universities.</h1>
      <h2 class="subtitle">
        A school management system demo supporting 3 types of user roles, interactive dashboard and
        event scheduler
      </h2>
      <div class="button-wrapper">
        <button class="main-button">Try it out</button>
        <button class="secondary-button">Learn more</button>
      </div>
    </div>
    <v-icon name="md-school-outlined" class="hero-image" fill="white"></v-icon>
  </section>
</template>

<style scoped>
#hero {
  width: 100%;

  display: flex;
  align-items: center;
  justify-content: space-between;
  background-color: #1f4873;
  background-image: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' version='1.1' xmlns:xlink='http://www.w3.org/1999/xlink' xmlns:svgjs='http://svgjs.com/svgjs' width='1440' height='560' preserveAspectRatio='none' viewBox='0 0 1440 560'%3e%3cg mask='url(%26quot%3b%23SvgjsMask1028%26quot%3b)' fill='none'%3e%3crect width='1440' height='560' x='0' y='0' fill='%230e2a47'%3e%3c/rect%3e%3cpath d='M0%2c636.746C119.542%2c645.942%2c233.635%2c584.891%2c330.337%2c514.014C423.255%2c445.91%2c488.826%2c349.876%2c535.247%2c244.439C581.189%2c140.09%2c598.258%2c28.503%2c594.261%2c-85.442C589.884%2c-210.226%2c580.93%2c-339.369%2c511.135%2c-442.901C437.136%2c-552.669%2c325.269%2c-637.917%2c197.779%2c-673.573C71.041%2c-709.019%2c-73.292%2c-703.807%2c-187.413%2c-638.27C-294.359%2c-576.853%2c-332.918%2c-446.791%2c-388.673%2c-336.787C-432.084%2c-251.136%2c-452.099%2c-161.416%2c-476.213%2c-68.469C-503.681%2c37.405%2c-574.44%2c142.799%2c-540.03%2c246.624C-505.193%2c351.737%2c-388.977%2c400.741%2c-299.214%2c465.587C-204.147%2c534.264%2c-116.934%2c627.751%2c0%2c636.746' fill='%230b2239'%3e%3c/path%3e%3cpath d='M1440 1060.157C1533.319 1055.242 1563.681 925.273 1641.424 873.422 1717.12 822.9359999999999 1834.284 838.74 1885.122 763.28 1936.299 687.317 1907.774 585.256 1896.829 494.318 1885.645 401.403 1889.365 293.756 1820.926 229.925 1752.911 166.49 1644.564 192.13400000000001 1553.35 173.96699999999998 1471.883 157.74099999999999 1394.859 112.57400000000001 1313.401 128.84300000000002 1228.772 145.745 1162.376 205.90800000000002 1099.1779999999999 264.676 1029.488 329.481 943.255 392.44 928.7819999999999 486.498 914.288 580.69 968.6949999999999 672.509 1024.539 749.734 1073.8519999999999 817.927 1157.048 845.012 1224.463 895.383 1298.407 950.6320000000001 1347.823 1065.012 1440 1060.157' fill='%23113255'%3e%3c/path%3e%3c/g%3e%3cdefs%3e%3cmask id='SvgjsMask1028'%3e%3crect width='1440' height='560' fill='white'%3e%3c/rect%3e%3c/mask%3e%3c/defs%3e%3c/svg%3e");
  background-repeat: no-repeat;
  background-size: cover;
  background-position: bottom;
}
.hero-image {
  width: 30%;
  min-width: 400px;
  height: 25%;
  padding: 3rem;
  padding: 5rem;
}
.heading-wrapper {
  width: 50%;
  padding: 5rem;
  /* background-color: #1f4873; */
  display: flex;
  flex-direction: column;
  justify-content: center;
  color: white;
  gap: 2rem;
}
.button-wrapper {
  display: flex;
  align-items: center;
  justify-content: flex-start;
  gap: 1rem;
}

@media (min-width: 768px) {
  .hero-main-button,
  .hero-secondary-button {
    padding: 0.75rem 1.5rem;
  }
}
@media (max-width: 850px) {
  #hero {
    flex-direction: column-reverse;
  }
  .heading-wrapper {
    width: 100%;
  }
  .hero-image {
    width: 50%;
  }
}
@media (max-width: 450px) {
  .hero-image {
    width: 75%;
    padding: 2rem;
    min-width: 350px;
  }
  .heading-wrapper {
    padding: 2rem;
  }
}
</style>
