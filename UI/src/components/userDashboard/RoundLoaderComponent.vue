<script></script>
<template>
  <div class="display">
    <div class="outer">
      <div class="inner">
        <div id="grade">5.35</div>
      </div>
    </div>
    <svg xmlns="http://www.w3.org/2000/svg" version="1.1" width="160px" height="160px">
      <defs>
        <linearGradient id="GradientColor">
          <stop offset="0%" stop-color="#ceff8f" />
          <stop offset="100%" stop-color="#0eff00" />
        </linearGradient>
      </defs>
      <circle cx="80" cy="80" r="70" stroke-linecap="round" />
    </svg>
  </div>
</template>
<style scoped>
.display {
  width: 15rem;
  height: 12.5rem;
  position: relative;
}
.outer {
  width: 10rem;
  height: 10rem;
  border-radius: 50%;
  padding: 1.25rem;
  /* box-shadow: 6px 6px 10px -1px rgba(0, 0, 0, 0.15), -6px -6px 10px -1px rgba(0, 0, 0, 0.15); */
}
.inner {
  width: 7.5rem;
  height: 7.5rem;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  /* box-shadow: inset 4px 4px 6px 1px rgba(0, 0, 0, 0.2), inset -4px -4px 6px -1px rgba(0, 0, 0, 0.2),
    -0.5px -0.5px 0px rgba(0, 0, 0, 1), 0.5px 0.5px 0px rgba(0, 0, 0, 0.15),
    0px 12px 10px -10px rgba(0, 0, 0, 0.05); */
}
#grade {
  font-weight: 600;
  color: 555;
  font-family: 'Roboto', sans-serif;
  font-size: 1.5rem;
}
circle {
  fill: none;
  stroke: url(#GradientColor);
  stroke-width: 1.25rem;
  stroke-dasharray: 439.6;
  stroke-dashoffset: 439.6;
  animation: fill 2s linear forwards;
}
@keyframes fill {
  100% {
    stroke-dashoffset: 156;
  }
}
svg {
  position: absolute;
  top: 0;
  left: 0;
}
</style>
